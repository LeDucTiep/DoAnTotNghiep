

<template>
  <div
    @click="openChat()"
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
        fill="#5f6368"
      >
        <path d="M504-480 320-664l56-56 240 240-240 240-56-56 184-184Z" />
      </svg>
    </div>
    <div class="icon">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512">
        <path
          fill="white"
          d="M256 32C114.6 32 0 125.1 0 240c0 49.6 21.4 95 57 130.7C44.5 421.1 2.7 466 2.2 466.5c-2.2 2.3-2.8 5.7-1.5 8.7S4.8 480 8 480c66.3 0 116-31.8 140.6-51.4 32.7 12.3 69 19.4 107.4 19.4 141.4 0 256-93.1 256-208S397.4 32 256 32z"
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
              v-if="!item.EmployeeID && item.UserID == wd.userID"
              height="32"
              width="32"
              src="../src/assets/images/persion.png"
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
      isOpenChat: false,
      wd: window,
      isExpandedChat: true,
      messageData: [],
      typingMessage: "",
    };
  },
  async created() {
    setInterval(() => {
      if (!this.isOpenChat) return;
      this.getMessages();
    }, 1000);

    this.isExpandedChat = localStorage.getItem("isExpandedChat") == "true";
  },
  methods: {
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
  cursor: pointer;
  .icon {
    width: 28px;
    height: 28px;
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
</style>
