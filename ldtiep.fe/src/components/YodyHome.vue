<template>
  <div class="yody-container">
    <div class="home-header d-flex">
      <div class="header-left">
        <span class="logo cursor-pointer"
          ><svg
            width="88"
            viewBox="0 0 68 32"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
            size="16"
            id=":r7:"
          >
            <path
              d="M25.1618 19.97C24.3798 19.9717 23.614 19.7453 22.9568 19.3181C22.2995 18.8909 21.7789 18.2812 21.4576 17.5625C21.1364 16.8437 21.0283 16.0466 21.1463 15.2673C21.2643 14.488 21.6034 13.7597 22.1227 13.1704C22.6421 12.581 23.3195 12.1556 24.0732 11.9456C24.827 11.7355 25.6249 11.7498 26.3708 11.9866C27.1167 12.2234 27.7787 12.6727 28.277 13.2802C28.7753 13.8878 29.0886 14.6277 29.1792 15.4107H33.2494C33.1273 13.2845 32.1878 11.29 30.6305 9.85073C29.0732 8.41146 27.0207 7.64081 24.9089 7.7024C22.7971 7.76399 20.7922 8.65297 19.3201 10.1806C17.8479 11.7082 17.0244 13.7541 17.0244 15.8839C17.0244 18.0137 17.8479 20.0596 19.3201 21.5873C20.7922 23.1149 22.7971 24.0039 24.9089 24.0654C27.0207 24.127 29.0732 23.3564 30.6305 21.9171C32.1878 20.4779 33.1273 18.4833 33.2494 16.3571H29.194C29.0788 17.3532 28.6042 18.2718 27.8607 18.938C27.1172 19.6042 26.1566 19.9715 25.1618 19.97Z"
              fill="#2A2A86"
            ></path>
            <path
              d="M11.8237 8.17431V16.1994C11.8237 18.2989 9.9736 19.9999 7.89092 19.9999C5.80824 19.9999 3.94123 18.2925 3.94123 16.1994V8.17431H0V16.1994C-3.72171e-08 17.2439 0.20412 18.2782 0.600702 19.2432C0.997284 20.2082 1.57856 21.085 2.31133 21.8235C3.04409 22.562 3.914 23.1477 4.87136 23.5473C5.82872 23.9468 6.85477 24.1523 7.89092 24.152C9.39426 24.152 10.5508 23.7662 11.8237 22.5918V24.1755C11.8237 26.275 10.1829 27.9759 7.89092 27.9759C5.59892 27.9759 3.77842 26.2707 3.77842 24.1755H0C0.0338903 26.2624 0.880046 28.2522 2.356 29.716C3.83195 31.1797 5.81943 32 7.88987 32C9.9603 32 11.9478 31.1797 13.4237 29.716C14.8997 28.2522 15.7458 26.2624 15.7797 24.1755V8.18923L11.8237 8.17431Z"
              fill="#2A2A86"
            ></path>
            <path
              d="M63.9584 8.17431V16.1994C63.9584 18.2989 62.1083 19.9999 60.0257 19.9999C57.943 19.9999 56.076 18.2947 56.076 16.1994V8.17431H52.1348V16.1994C52.1348 17.2439 52.3389 18.2782 52.7355 19.2432C53.132 20.2082 53.7133 21.085 54.4461 21.8235C55.1788 22.562 56.0488 23.1477 57.0061 23.5473C57.9635 23.9468 58.9895 24.1523 60.0257 24.152C61.529 24.152 62.6856 23.7662 63.9584 22.5918V24.1755C63.9584 26.275 62.3177 27.9759 60.0257 27.9759C57.7337 27.9759 55.9132 26.2707 55.9132 24.1755H52.1348C52.1687 26.2624 53.0148 28.2522 54.4908 29.716C55.9667 31.1797 57.9542 32 60.0246 32C62.095 32 64.0825 31.1797 65.5585 29.716C67.0344 28.2522 67.8806 26.2624 67.9145 24.1755V8.18923L63.9584 8.17431Z"
              fill="#FCAF17"
            ></path>
            <path
              d="M46.9376 0V9.10363C45.7319 8.20855 44.276 7.72131 42.7786 7.71176C38.5498 7.71176 35.1118 11.1222 34.875 15.4129H38.9262C39.0457 14.3725 39.5553 13.4177 40.3507 12.7439C41.146 12.07 42.1668 11.7283 43.2039 11.7887C44.2411 11.849 45.2161 12.3069 45.9292 13.0685C46.6423 13.8301 47.0396 14.8377 47.0396 15.885C47.0396 16.9323 46.6423 17.9399 45.9292 18.7015C45.2161 19.4631 44.2411 19.9209 43.2039 19.9813C42.1668 20.0417 41.146 19.6999 40.3507 19.0261C39.5553 18.3523 39.0457 17.3974 38.9262 16.3571H34.875C35.1139 20.6499 38.5604 24.0561 42.7786 24.0561C44.2878 24.0288 45.7514 23.5298 46.9672 22.628L47.5423 23.8685H50.9063V0H46.9376Z"
              fill="#FCAF17"
            ></path></svg
        ></span>

        <div class="header__menu d-flex">
          <Popover :hover="true" :arrow="true">
            <div class="menu-item">BST Thu Đông</div>
            <template #content>
              <div class="menu-popover">
                <div>Nguồn cảm ứng</div>
                <div>Áo gió 3C</div>
                <div>Áo phao 4S</div>
                <div>Quần Jeans</div>
                <div>Áo giữ nhiệt</div>
                <div>Áo polo</div>
                <div>Đồ công sở</div>
              </div>
            </template>
          </Popover>
          <div class="menu-item">Mới về</div>
          <div class="menu-item">Bán chạy</div>
          <div class="menu-item">Nam</div>
          <div class="menu-item">Nữ</div>
          <div class="menu-item">Trẻ em</div>
          <div class="menu-item">Ưu đãi</div>
          <div class="menu-item">Bộ sưu tập</div>
          <div class="menu-item">Đồng phục</div>
          <div class="menu-item">Tin hot</div>
        </div>
      </div>

      <div class="header-right">
        <div class="input-search">
          <div class="icon-search">
            <svg
              width="20"
              height="20"
              viewBox="0 0 24 24"
              fill="none"
              color="#0F0F0F"
              xmlns="http://www.w3.org/2000/svg"
              id=":r1:"
            >
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M17.1956 15.3101L22.5 20.6145L21.1145 22L15.8101 16.6956L17.1956 15.3101Z"
                fill="currentcolor"
              ></path>
              <path
                fill-rule="evenodd"
                clip-rule="evenodd"
                d="M11.3174 3.95942C7.52983 3.95942 4.45942 7.02983 4.45942 10.8174C4.45942 14.6049 7.52983 17.6754 11.3174 17.6754C15.1049 17.6754 18.1754 14.6049 18.1754 10.8174C18.1754 7.02983 15.1049 3.95942 11.3174 3.95942ZM2.5 10.8174C2.5 5.94768 6.44768 2 11.3174 2C16.1871 2 20.1348 5.94768 20.1348 10.8174C20.1348 15.6871 16.1871 19.6348 11.3174 19.6348C6.44768 19.6348 2.5 15.6871 2.5 10.8174Z"
                fill="currentcolor"
              ></path>
            </svg>
          </div>

          <input v-model="inputValue" placeholder="Enter your name" />
        </div>
        <div class="m-l-10 store-items">
          <svg
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
            id=":r2:"
            class="cursor-pointer"
          >
            <path
              fill-rule="evenodd"
              clip-rule="evenodd"
              d="M7.33784 11.7042C6.93552 11.7042 6.60937 11.3781 6.60937 10.9758L6.60937 6.31356C6.60937 3.33638 9.02286 0.922899 12 0.9229C14.9772 0.922899 17.3907 3.33638 17.3907 6.31356L17.3907 10.9758C17.3907 11.3781 17.0646 11.7042 16.6622 11.7042C16.2599 11.7042 15.9338 11.3781 15.9338 10.9758L15.9338 6.31356C15.9338 4.14102 14.1726 2.37984 12 2.37984C9.8275 2.37984 8.06631 4.14102 8.06631 6.31356L8.06631 10.9758C8.06631 11.3781 7.74016 11.7042 7.33784 11.7042Z"
              fill="currentcolor"
            ></path>
            <path
              fill-rule="evenodd"
              clip-rule="evenodd"
              d="M6.91637 6.75H17.0841C18.0602 6.74998 18.8632 6.74996 19.5029 6.83303C20.174 6.92018 20.7632 7.1089 21.2514 7.55809C21.7395 8.00728 21.9765 8.57871 22.1191 9.24032C22.255 9.87092 22.3217 10.6711 22.4027 11.6439L23.0097 18.9277C23.0556 19.4773 23.0961 19.9629 23.0746 20.3561C23.0514 20.7816 22.9519 21.2182 22.6172 21.582C22.2825 21.9457 21.8556 22.0811 21.4336 22.1396C21.0436 22.1936 20.5562 22.1936 20.0047 22.1935H3.99574C3.44422 22.1936 2.95689 22.1936 2.56689 22.1396C2.1448 22.0811 1.71792 21.9457 1.38323 21.582C1.04854 21.2182 0.949032 20.7816 0.925824 20.3561C0.90438 19.9629 0.94489 19.4773 0.990735 18.9277L1.59772 11.6439C1.67876 10.6711 1.74543 9.87092 1.88133 9.24032C2.02392 8.57871 2.26091 8.00728 2.74909 7.55809C3.23727 7.1089 3.82641 6.92018 4.49757 6.83303C5.13729 6.74996 5.94027 6.74998 6.91637 6.75ZM4.68519 8.27783C4.171 8.3446 3.91654 8.46373 3.7356 8.63022C3.55465 8.79671 3.41481 9.0404 3.30557 9.54726C3.19193 10.0745 3.13171 10.7798 3.04553 11.814L2.44663 19.0009C2.39562 19.6129 2.36531 19.9965 2.3806 20.2767C2.39441 20.5299 2.4415 20.5806 2.45449 20.5945L2.45536 20.5955L2.45623 20.5964C2.46906 20.6105 2.51558 20.6616 2.76678 20.6964C3.04478 20.7349 3.42954 20.7366 4.04372 20.7366H19.9567C20.5709 20.7366 20.9557 20.7349 21.2337 20.6964C21.4849 20.6616 21.5314 20.6105 21.5442 20.5964L21.5451 20.5955L21.546 20.5945C21.559 20.5806 21.606 20.5299 21.6198 20.2767C21.6351 19.9965 21.6048 19.6129 21.5538 19.0009L20.9549 11.814C20.8687 10.7798 20.8085 10.0745 20.6949 9.54726C20.5856 9.0404 20.4458 8.79671 20.2648 8.63022C20.0839 8.46373 19.8294 8.3446 19.3153 8.27783C18.7804 8.20838 18.0725 8.20694 17.0348 8.20694H6.96567C5.92794 8.20694 5.22008 8.20838 4.68519 8.27783Z"
              fill="currentcolor"
            ></path>
          </svg>
        </div>
      </div>
    </div>

    <div class="home-body">
      <div class="ontop-swiper">
        <div class="swiper-container">
          <swiper
            ref="mySwiper"
            :slides-per-view="1"
            @swiper="onSwiper"
            :space-between="50"
          >
            <swiper-slide>
              <img
                loading="lazy"
                decoding="async"
                class="w-full"
                src="https://m.yodycdn.com/fit-in/filters:format(webp)/fit-in/filters:format(webp)/products/m2icp1q482izgs5xlwrluong-ve-sale-to-1800x833.png"
                style="color: transparent"
              />
            </swiper-slide>
            <swiper-slide
              ><img
                loading="lazy"
                decoding="async"
                class="w-full"
                src="https://m.yodycdn.com/fit-in/filters:format(webp)/fit-in/filters:format(webp)/products/m1h5t6esl6r65pev2xp1800x833%20bst%20thu%20dong%20pc.png"
                style="color: transparent"
            /></swiper-slide>
            <swiper-slide
              ><img
                loading="lazy"
                decoding="async"
                class="w-full"
                src="https://m.yodycdn.com/fit-in/filters:format(webp)/fit-in/filters:format(webp)/products/m1acnkuz77djwysa293c%C3%B3%20cta%201800x833.png"
                style="color: transparent"
            /></swiper-slide>
            <swiper-slide
              ><img
                loading="lazy"
                decoding="async"
                class="w-full"
                src="https://m.yodycdn.com/fit-in/filters:format(webp)/fit-in/filters:format(webp)/products/m2icqji8qcsbiegy6ildp-hlw-1800x833.png"
                style="color: transparent"
            /></swiper-slide>
          </swiper>
        </div>
        <div class="z-2 left-swiper" @click="backSwiper()">
          <svg
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
            id=":r5:"
            class="text-yd-typo-title"
          >
            <path
              d="M14.9998 20.67C14.8098 20.67 14.6198 20.6 14.4698 20.45L7.94979 13.93C6.88979 12.87 6.88979 11.13 7.94979 10.07L14.4698 3.55002C14.7598 3.26002 15.2398 3.26002 15.5298 3.55002C15.8198 3.84002 15.8198 4.32002 15.5298 4.61002L9.00979 11.13C8.52979 11.61 8.52979 12.39 9.00979 12.87L15.5298 19.39C15.8198 19.68 15.8198 20.16 15.5298 20.45C15.3798 20.59 15.1898 20.67 14.9998 20.67Z"
              fill="currentcolor"
            ></path>
          </svg>
        </div>
        <div class="z-2 right-swiper" @click="nextSwiper()">
          <svg
            width="24"
            height="24"
            viewBox="0 0 24 24"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
            id=":r6:"
            class="text-yd-typo-title"
          >
            <path
              d="M8.9101 20.67C8.7201 20.67 8.5301 20.6 8.3801 20.45C8.0901 20.16 8.0901 19.68 8.3801 19.39L14.9001 12.87C15.3801 12.39 15.3801 11.61 14.9001 11.13L8.3801 4.61002C8.0901 4.32002 8.0901 3.84002 8.3801 3.55002C8.6701 3.26002 9.1501 3.26002 9.4401 3.55002L15.9601 10.07C16.4701 10.58 16.7601 11.27 16.7601 12C16.7601 12.73 16.4801 13.42 15.9601 13.93L9.4401 20.45C9.2901 20.59 9.1001 20.67 8.9101 20.67Z"
              fill="currentcolor"
            ></path>
          </svg>
        </div>
      </div>

      <div class="ua-chuong">
        <div class="title">Sản phẩm ưa chuộng</div>

        <div class="ua-chuong-buttons">
          <div
            v-for="(item, index) in [
              'Áo Gió',
              'Jeans Flex',
              'Áo Polo',
              'Quần Âu',
              'Sơ Mi',
            ]"
            :key="index"
            class="ua-chuong-b"
            :class="{ 'ua-chuong-b--active': currUaChuongId == index }"
            @click="changeUaChuong(index)"
          >
            <div class="b-block">
              {{ item }}
            </div>
          </div>
        </div>

        <div class="uacuong-products">
          <div class="product-row">
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
          </div>
        </div>

        <div class="view-more-product">
          <div class="button-view-more">Xem thêm</div>
        </div>
      </div>
    </div>

    <div class="home-footer"></div>
  </div>
</template>

<script>
import { Swiper, SwiperSlide } from "swiper/vue";
import "swiper/css";
import Popover from "popover-vue";
import ProductSP from "/src/components/cloth/ProductSP.vue";
export default {
  name: "YodyHome",
  components: {
    Popover,
    Swiper,
    SwiperSlide,
    ProductSP,
  },
  props: {},
  data() {
    return {
      inputValue: "",
      currUaChuongId: 0,
      swiper: null,
    };
  },
  methods: {
    changeUaChuong(i) {
      this.currUaChuongId = i;
    },
    onSwiper(swiper) {
      this.swiper = swiper;
    },
    nextSwiper() {
      const current = this.swiper.activeIndex;
      const max = 4;
      let now = current + 1;

      if (now > max) now = max;

      this.swiper.slideTo(now);
    },
    backSwiper() {
      const current = this.swiper.activeIndex;
      const min = 1;
      let now = current - 1;

      if (now < min) now = min;

      this.swiper.slideTo(now);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
@import "/src/components/YodyHome.scss";
</style>
