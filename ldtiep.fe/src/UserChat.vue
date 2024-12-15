

<template>
  <div
    :class="`chat-container ${
      isExpandedChat ? 'chat-container--big' : 'chat-container--small'
    }`"
  >
    <div @click.stop="onHideChat($event)" class="navigate-button">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        height="24px"
        viewBox="0 -960 960 960"
        width="24px"
        fill="#fff"
      >
        <path d="M504-480 320-664l56-56 240 240-240 240-56-56 184-184Z" />
      </svg>
    </div>
    <div class="icon">
      <svg
        @click.stop="openChat()"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 512 512"
      >
        <path
          fill="white"
          d="M256 32C114.6 32 0 125.1 0 240c0 49.6 21.4 95 57 130.7C44.5 421.1 2.7 466 2.2 466.5c-2.2 2.3-2.8 5.7-1.5 8.7S4.8 480 8 480c66.3 0 116-31.8 140.6-51.4 32.7 12.3 69 19.4 107.4 19.4 141.4 0 256-93.1 256-208S397.4 32 256 32z"
        />
      </svg>
      <svg
        @click.stop="openUserInfor()"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 -960 960 960"
        fill="#fff"
      >
        <path
          d="M160-40v-80h640v80H160Zm0-800v-80h640v80H160Zm320 400q50 0 85-35t35-85q0-50-35-85t-85-35q-50 0-85 35t-35 85q0 50 35 85t85 35ZM160-160q-33 0-56.5-23.5T80-240v-480q0-33 23.5-56.5T160-800h640q33 0 56.5 23.5T880-720v480q0 33-23.5 56.5T800-160H160Zm70-80q45-56 109-88t141-32q77 0 141 32t109 88h70v-480H160v480h70Zm118 0h264q-29-20-62.5-30T480-280q-36 0-69.5 10T348-240Zm132-280q-17 0-28.5-11.5T440-560q0-17 11.5-28.5T480-600q17 0 28.5 11.5T520-560q0 17-11.5 28.5T480-520Zm0 40Z"
        />
      </svg>
    </div>
  </div>

  <vs-popup fullscreen title="Tư vấn khách hàng" v-model:active="isOpenChat">
    <div class="chat-screen">
      <!-- <div class="chat-screen__header"></div> -->
      <div class="chat-screen__body scroll bg">
        <div
          v-for="item in messageData"
          :key="item"
          class="message-row"
          :class="
            !item.EmployeeID && item.UserID == wd.userID
              ? 'message-row--right'
              : 'message-row--left'
          "
        >
          <div class="message-avata">
            <img
              v-if="
                !item.EmployeeID && item.UserID == wd.userID && !ownAvata?.src
              "
              height="32"
              width="32"
              src="../src/assets/images/persion.png"
              alt="Avata"
            />
            <img
              v-else-if="
                !item.EmployeeID && item.UserID == wd.userID && ownAvata?.src
              "
              style="border-radius: 50%"
              height="32"
              width="32"
              :src="ownAvata?.src"
              alt="Avata"
            />
            <img
              v-else
              style="border-radius: 50%"
              height="32"
              width="32"
              src="../src/assets/images/avata-cham-soc-khach-hang.jpg"
              alt="Avata"
            />
          </div>
          <div class="message-content">
            <div class="message--text bg2">{{ item.MessageContent }}</div>
            <div class="message-time d-flex">
              {{ formatTime(item.CreatedDate) }}
            </div>
          </div>
        </div>
      </div>
      <div class="chat-screen__footer">
        <vs-input
          icon="send"
          :autofocus="true"
          v-model="typingMessage"
          @icon-click="sendMessage()"
          size="large"
        />

        <vs-button @click="sendMessage()" color="primary" type="filled"
          >Gửi</vs-button
        >
      </div>
    </div>
  </vs-popup>

  <vs-popup
    fullscreen
    title="Thông tin người dùng"
    v-model:active="isOpenUserInfor"
  >
    <div class="user-infor-screen">
      <div class="user-infor-screen--body">
        <div class="product-image">
          <div class="tiep-input-upload">
            <input
              ref="uploadInput"
              accept="image/*"
              type="file"
              @change="handleFileUpload"
            /><span class="text-input">Chọn ảnh đại diện</span
            ><span class="input-progress" style="width: 0%"></span
            ><button
              @click="$refs.uploadInput.click()"
              class="btn-upload-all vs-upload--button-upload"
            >
              <i translate="no" class="material-icons notranslate">
                cloud_upload
              </i>
            </button>
          </div>
          <div
            :key="img.src"
            v-for="(img, index) in imageSrcs"
            class="img-preview-blog"
          >
            <vs-chip @click="remove(index)" closable>
              <img width="160" height="auto" :src="img.src" />
            </vs-chip>
          </div>
        </div>
        <div class="user-fullname">
          <vs-input
            :danger="isValidating && !userInfor.UserName"
            danger-text="Không được để trống"
            icon="person"
            v-model="userInfor.UserName"
            size="large"
          />
        </div>
      </div>

      <vs-button @click="confirmUserInfor()" color="primary" type="filled"
        >Xác nhận</vs-button
      >
    </div>
  </vs-popup>
</template>


<script>
import API from "/src/service/api.js";
export default {
  name: "UserChat",
  components: {},
  props: {},
  data() {
    return {
      MessageApi: new API("Messages"),
      PictureApi: new API("Pictures"),
      UserApi: new API("Users"),
      isOpenChat: false,
      isValidating: false,
      wd: window,
      isExpandedChat: true,
      isOpenUserInfor: false,
      messageData: [],
      typingMessage: "",
      imageSrcs: [],
      ownAvata: null,
      userInfor: {},
    };
  },
  async created() {
    setInterval(() => {
      if (!this.isOpenChat) return;
      this.getMessages();
    }, 1000);

    this.isExpandedChat = localStorage.getItem("isExpandedChat") == "true";
  },
  async mounted() {
    const user = await this.UserApi.byID(this.wd.userID);

    if (user) {
      if (user.PictureID) {
        const dataTransfer = new DataTransfer();

        const file = await this.PictureApi.blobImage(user.PictureID);

        dataTransfer.items.add(file);

        this.userInfor.Files = dataTransfer.files;

        this.ownAvata = {
          src: URL.createObjectURL(file),
          file: file,
        };
      }

      this.userInfor.UserName = user.UserName;
    }
  },
  methods: {
    openUserInfor() {
      this.isOpenUserInfor = true;

      this.$refs.uploadInput.files = this.userInfor.Files;
      this.$refs.uploadInput.dispatchEvent(new Event("change"));
    },
    handleFileUpload(event) {
      const files = event.target.files;

      for (let i = 0; i < files.length; i++) {
        this.imageSrcs = [
          {
            src: URL.createObjectURL(files[i]),
            file: files[i],
          },
        ];
      }
      if (this.$refs.uploadInput) this.$refs.uploadInput.value = null;
    },
    remove(index) {
      this.imageSrcs.splice(index, 1);
    },
    validateForm() {
      this.isValidating = true;

      if (!this.userInfor.UserName) {
        return false;
      }

      return true;
    },
    async confirmUserInfor() {
      if (!this.validateForm()) return;

      let PictureID = null;

      if (this.imageSrcs.length) {
        const pic = await this.PictureApi.upFile(this.imageSrcs[0].file);

        PictureID = pic.PictureID;
      }

      const param = {
        UserID: this.wd.userID,
        PictureID: PictureID,
        UserName: this.userInfor.UserName,
      };

      const user = await this.UserApi.byID(this.wd.userID);

      if (!user) {
        this.UserApi.add(param);
      } else {
        this.UserApi.updateByID(this.wd.userID, param);
      }

      this.isOpenUserInfor = false;
    },
    openChat() {
      this.isOpenChat = true;
    },
    onHideChat(e) {
      e.preventDefault();
      this.isExpandedChat = !this.isExpandedChat;

      localStorage.setItem("isExpandedChat", `${this.isExpandedChat}`);
    },
    async getMessages() {
      const param = {
        PageSize: 100,
        PageNumber: 1,
        Sorter: {
          CreatedDate: "asc",
        },
        SearchEquals: {
          UserID: this.wd.userID,
        },
      };
      const res = await this.MessageApi.paging(param);

      if (JSON.stringify(this.messageData) != JSON.stringify(res.Data)) {
        this.messageData = res.Data;
      }
    },
    formatTime(time) {
      const t = new Date(time);
      const now = new Date();

      // Kiểm tra xem có cùng ngày không
      const isToday = t.toDateString() === now.toDateString();

      // Định dạng thời gian
      if (isToday) {
        return (
          t.toLocaleTimeString("vi-VN", {
            hour: "2-digit",
            minute: "2-digit",
          }) + ", hôm nay"
        );
      } else {
        const options = { year: "numeric", month: "long", day: "numeric" };
        return t.toLocaleDateString("vi-VN", options);
      }
    },
    async sendMessage() {
      if (!this.typingMessage) return;

      const param = {
        UserID: window.userID,
        MessageContent: this.typingMessage,
      };

      await this.MessageApi.add(param);

      this.typingMessage = "";
    },
  },
};
</script>

<style scoped lang="scss">
.chat-container--small {
  .navigate-button svg {
    transform: scaleX(-1);
    -moz-transform: scaleX(-1);
    -webkit-transform: scaleX(-1);
    -ms-transform: scaleX(-1);
  }
  right: -52px !important;
}

.chat-container {
  transition: right 1s ease-in-out;
  z-index: 10000;
  right: 0;
  position: fixed;
  top: 45%;
  padding: 12px;
  background-color: #fcaf17;
  border-top-left-radius: 12px;
  border-bottom-left-radius: 12px;
  .icon {
    width: 28px;

    display: flex;
    flex-direction: column;
    gap: 12px;

    svg {
      cursor: pointer;
    }
  }
  .navigate-button {
    position: fixed;
    width: 24px;
    height: 35px;
    background-color: #fcaf17;
    border-top-left-radius: 12px;
    border-bottom-left-radius: 12px;
    display: flex;
    justify-content: center;
    align-items: center;
    right: 0;
    top: 41%;
  }
}

.chat-screen {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 100%;

  .chat-screen__header {
    height: 100px;
    width: 100%;
    background: red;
  }
  .bg {
    background: linear-gradient(to right, #67b04e, #40bede);
  }
  .bg2 {
    background: #75d87aff;
  }
  .chat-screen__body {
    width: 100%;
    height: 100%;
    font-family: sans-serif;
    letter-spacing: 0.4px;
    color: #000;
    line-height: 20px;
    padding: 12px;
    border-radius: 12px;

    .message-row {
      display: flex;
      flex-direction: row;
      gap: 8px;

      .message-avata {
        border-radius: 50%;
      }

      .message--text {
        padding: 12px;
        border-radius: 12px;
        box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
      }

      .message-content {
        display: flex;
        flex-direction: column;
        gap: 4px;
      }
    }
    .message-row--right {
      justify-content: right;

      .message-avata {
        order: 2;
      }
      .message-content {
        order: 1;
      }
      .message-time {
        justify-content: end;
      }
    }
  }
  .chat-screen__footer {
    width: 100%;
    height: 67px;

    display: flex;
    gap: 12px;
    padding: 12px 0;

    .vs-button-primary.vs-button-filled.vs-component.vs-button {
      width: 80px;
    }
    .vs-input-primary.vs-component.vs-con-input-label.vs-input {
      width: 100%;
    }
  }
  .message-time {
    color: white;
    font-size: 12px;
    position: relative;
    top: -2px;
  }
}
.product-image {
  align-items: center;
}
.user-infor-screen {
  justify-content: center;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.user-infor-screen--body {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: start;
  width: 600px;
  padding-bottom: 20px;

  .user-fullname {
    padding: 0 14px;
    width: 100%;

    .vs-input-primary {
      width: 100%;
    }
  }
}
</style>
