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
          <Popover :arrow="true">
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

          <input v-model="inputValue" placeholder="Tìm kiếm" />
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
      <div class="san-pham-tot">
        <img
          loading="lazy"
          decoding="async"
          class="w-full h-full"
          src="https://m.yodycdn.com/fit-in/filters:format(webp)//products/BANNER%20%20COLLECTION%20LIST-2.png"
          style="color: transparent"
        />
      </div>
      <div class="goi-y">
        <div class="goi-y-title">
          <div class="left">Gợi ý sản phẩm</div>
          <div class="right">
            <Popover
              @open:popover="isShowGoiY = true"
              @close:popover="isShowGoiY = false"
            >
              <div class="goi-y-show d-flex">
                <div class="goi-y-right">{{ GoiYs[currGoiYId] }}</div>

                <div class="icon-right">
                  <svg
                    v-show="!isShowGoiY"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      d="M12 16.8C11.3 16.8 10.6 16.53 10.07 16L3.55002 9.48001C3.26002 9.19001 3.26002 8.71001 3.55002 8.42001C3.84002 8.13001 4.32002 8.13001 4.61002 8.42001L11.13 14.94C11.61 15.42 12.39 15.42 12.87 14.94L19.39 8.42001C19.68 8.13001 20.16 8.13001 20.45 8.42001C20.74 8.71001 20.74 9.19001 20.45 9.48001L13.93 16C13.4 16.53 12.7 16.8 12 16.8Z"
                      fill="currentcolor"
                    ></path>
                  </svg>
                  <svg
                    v-show="isShowGoiY"
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                    xmlns="http://www.w3.org/2000/svg"
                    id=":rdp:"
                    class="text-black"
                  >
                    <path
                      d="M19.92 15.8C19.73 15.8 19.54 15.73 19.39 15.58L12.87 9.05996C12.39 8.57996 11.61 8.57996 11.13 9.05996L4.61002 15.58C4.32002 15.87 3.84002 15.87 3.55002 15.58C3.26002 15.29 3.26002 14.81 3.55002 14.52L10.07 7.99996C11.13 6.93996 12.86 6.93996 13.93 7.99996L20.45 14.52C20.74 14.81 20.74 15.29 20.45 15.58C20.3 15.72 20.11 15.8 19.92 15.8Z"
                      fill="currentcolor"
                    ></path>
                  </svg>
                </div>
              </div>
              <template #content>
                <div class="goi-y-menu">
                  <div
                    v-for="(item, index) in GoiYs"
                    :key="index"
                    class="goi-y-item"
                    :class="{ 'goi-y-item--active': currGoiYId == index }"
                    @click="changeGoiY(index)"
                  >
                    {{ item }}
                  </div>
                </div>
              </template>
            </Popover>
          </div>
        </div>
        <div class="products-block">
          <div class="product-row">
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
            <ProductSP></ProductSP>
          </div>
          <div class="product-row">
            <ProductSP></ProductSP>
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
    <div class="gioi-thieu">
      <div class="gioi-thieu-header">#Yody tự hào thương hiệu Việt</div>
      <div class="infor-tags">
        <div class="tags">
          <img
            src="https://m.yodycdn.com/fit-in/filters:format(webp)/products/media/articles/280.jpeg"
            loading="lazy"
            class="w-full h-full object-cover"
            alt="media"
          />
          <div class="title">
            YODY Cán Mốc 280 Cửa Hàng - Thương hiệu Thời trang Chinh Phục Mọi
            Miền Đất Nước
          </div>
          <div class="detail">
            Thương hiệu thời trang Việt Nam YODY vừa ghi dấu ấn mới trong hành
            trình phát triển của mình khi chính thức cán mốc 280 cửa hàng trên
            toàn quốc
          </div>
        </div>
        <div class="tags">
          <img
            src="https://m.yodycdn.com/fit-in/filters:format(webp)/products/media/articles/yody-chung-tay-tu-thien-thumb.webp"
            loading="lazy"
            class="h-full w-full object-cover"
            alt="media"
          />
          <div class="title">
            NHÌN LẠI HÀNH TRÌNH CHUNG TAY CÙNG ĐỒNG BÀO VÙNG BÃO LŨ
          </div>
          <div class="detail">
            YODY biết ơn khách hàng đã tin tưởng, đồng hành cùng YODY trong suốt
            thời gian qua. Sự ủng hộ và tình cảm của khách hàng khắp nơi gửi về
            chính là nguồn động lực to lớn để YODY tiếp tục lan tỏa những giá
            trị tốt đẹp đến cộng đồng.
          </div>
        </div>
      </div>
    </div>

    <div class="home-footer">
      <div class="dich-vu">
        <div class="title">Dịch vụ khách hàng</div>
        <div class="urls">
          <div class="url">Chính sách khách hàng thân thiết</div>
          <div class="url">Chính sách khách hàng thân thiết</div>
          <div class="url">Chính sách khách hàng thân thiết</div>
          <div class="url">Chính sách khách hàng thân thiết</div>
          <div class="url">Chính sách khách hàng thân thiết</div>
          <div class="url">Chính sách đổi trả</div>
          <div class="url">Chính sách bảo mật</div>
          <div class="url">Chính sách sử dụng Cookies</div>
          <div class="url">Chính sách thanh toán, giao nhận</div>
          <div class="url">Chính sách đơn đồng phục</div>
          <div class="url">Hướng dẫn chọn size</div>
          <div class="url">Đăng ký đối tác</div>
        </div>
      </div>

      <div class="about-yody">
        <div class="title">Về YODY</div>
        <div class="urls">
          <div class="url">Giới thiệu</div>
          <div class="url">Liên hệ</div>
          <div class="url">Tuyển dụng</div>
          <div class="url">Tin tức</div>
          <div class="url">Hệ thống cửa hàng</div>
          <div class="url">Tin khuyến mãi</div>
        </div>

        <div class="title">Địa chỉ liên hệ</div>
        <div class="urls">
          <div class="url">
            Địa chỉ: Đường An Định - Phường Việt Hòa - Thành phố Hải Dương
          </div>
        </div>
      </div>

      <div class="yody-lang-nghe-ban">
        <div class="title">YODY lắng nghe bạn</div>
        <div class="sub-title">
          Chúng tôi luôn trân trọng và mong đợi nhận được mọi ý kiến đóng góp từ
          khách hàng để có thể nâng cấp trải nghiệm dịch vụ và sản phẩm tốt hơn
          nữa.
        </div>
        <div class="lien-he">
          <div class="phone-number">
            <div class="icon">
              <svg
                width="16"
                height="16"
                viewBox="0 0 24 24"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":raj:"
                class="-rotate-90 text-yd-typo-disabled w-6 h-6 md:w-7 md:h-7"
              >
                <path
                  d="M17.45 22.75C16.32 22.75 15.13 22.48 13.9 21.96C12.7 21.45 11.49 20.75 10.31 19.9C9.14 19.04 8.01 18.08 6.94 17.03C5.88 15.96 4.92 14.83 4.07 13.67C3.21 12.47 2.52 11.27 2.03 10.11C1.51 8.87 1.25 7.67 1.25 6.54C1.25 5.76 1.39 5.02 1.66 4.33C1.94 3.62 2.39 2.96 3 2.39C3.77 1.63 4.65 1.25 5.59 1.25C5.98 1.25 6.38 1.34 6.72 1.5C7.11 1.68 7.44 1.95 7.68 2.31L10 5.58C10.21 5.87 10.37 6.15 10.48 6.43C10.61 6.73 10.68 7.03 10.68 7.32C10.68 7.7 10.57 8.07 10.36 8.42C10.21 8.69 9.98 8.98 9.69 9.27L9.01 9.98C9.02 10.01 9.03 10.03 9.04 10.05C9.16 10.26 9.4 10.62 9.86 11.16C10.35 11.72 10.81 12.23 11.27 12.7C11.86 13.28 12.35 13.74 12.81 14.12C13.38 14.6 13.75 14.84 13.97 14.95L13.95 15L14.68 14.28C14.99 13.97 15.29 13.74 15.58 13.59C16.13 13.25 16.83 13.19 17.53 13.48C17.79 13.59 18.07 13.74 18.37 13.95L21.69 16.31C22.06 16.56 22.33 16.88 22.49 17.26C22.64 17.64 22.71 17.99 22.71 18.34C22.71 18.82 22.6 19.3 22.39 19.75C22.18 20.2 21.92 20.59 21.59 20.95C21.02 21.58 20.4 22.03 19.68 22.32C18.99 22.6 18.24 22.75 17.45 22.75ZM5.59 2.75C5.04 2.75 4.53 2.99 4.04 3.47C3.58 3.9 3.26 4.37 3.06 4.88C2.85 5.4 2.75 5.95 2.75 6.54C2.75 7.47 2.97 8.48 3.41 9.52C3.86 10.58 4.49 11.68 5.29 12.78C6.09 13.88 7 14.95 8 15.96C9 16.95 10.08 17.87 11.19 18.68C12.27 19.47 13.38 20.11 14.48 20.57C16.19 21.3 17.79 21.47 19.11 20.92C19.62 20.71 20.07 20.39 20.48 19.93C20.71 19.68 20.89 19.41 21.04 19.09C21.16 18.84 21.22 18.58 21.22 18.32C21.22 18.16 21.19 18 21.11 17.82C21.08 17.76 21.02 17.65 20.83 17.52L17.51 15.16C17.31 15.02 17.13 14.92 16.96 14.85C16.74 14.76 16.65 14.67 16.31 14.88C16.11 14.98 15.93 15.13 15.73 15.33L14.97 16.08C14.58 16.46 13.98 16.55 13.52 16.38L13.25 16.26C12.84 16.04 12.36 15.7 11.83 15.25C11.35 14.84 10.83 14.36 10.2 13.74C9.71 13.24 9.22 12.71 8.71 12.12C8.24 11.57 7.9 11.1 7.69 10.71L7.57 10.41C7.51 10.18 7.49 10.05 7.49 9.91C7.49 9.55 7.62 9.23 7.87 8.98L8.62 8.2C8.82 8 8.97 7.81 9.07 7.64C9.15 7.51 9.18 7.4 9.18 7.3C9.18 7.22 9.15 7.1 9.1 6.98C9.03 6.82 8.92 6.64 8.78 6.45L6.46 3.17C6.36 3.03 6.24 2.93 6.09 2.86C5.93 2.79 5.76 2.75 5.59 2.75ZM13.95 15.01L13.79 15.69L14.06 14.99C14.01 14.98 13.97 14.99 13.95 15.01Z"
                  fill="currentcolor"
                ></path>
              </svg>
            </div>
            <div class="detail">
              <div class="name">Liên hệ đặt hàng</div>
              <div class="value">024 999 86 999</div>
            </div>
          </div>
          <div class="hotline">
            <div class="icon">
              <svg
                width="16"
                height="16"
                viewBox="0 0 24 24"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":rak:"
                class="text-yd-typo-disabled w-6 h-6 md:w-7 md:h-7"
              >
                <path
                  d="M17 18.43H13L8.54999 21.39C7.88999 21.83 7 21.36 7 20.56V18.43C4 18.43 2 16.43 2 13.43V7.42993C2 4.42993 4 2.42993 7 2.42993H17C20 2.42993 22 4.42993 22 7.42993V13.43C22 16.43 20 18.43 17 18.43Z"
                  stroke="currentcolor"
                  stroke-width="1.5"
                  stroke-miterlimit="10"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
                <path
                  d="M11.9998 11.36V11.15C11.9998 10.47 12.4198 10.11 12.8398 9.82001C13.2498 9.54001 13.6598 9.18002 13.6598 8.52002C13.6598 7.60002 12.9198 6.85999 11.9998 6.85999C11.0798 6.85999 10.3398 7.60002 10.3398 8.52002"
                  stroke="currentcolor"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
                <path
                  d="M11.9955 13.75H12.0045"
                  stroke="currentcolor"
                  stroke-width="1.5"
                  stroke-linecap="round"
                  stroke-linejoin="round"
                ></path>
              </svg>
            </div>
            <div class="detail">
              <div class="name">Góp ý khiếu nại</div>
              <div class="value">1800 2086</div>
            </div>
          </div>
          <div class="email">
            <div class="icon">
              <svg
                width="16"
                height="16"
                viewBox="0 0 24 24"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":ral:"
                class="text-yd-typo-disabled w-6 h-6 md:w-7 md:h-7"
              >
                <path
                  d="M17 21.25H7C3.35 21.25 1.25 19.15 1.25 15.5V8.5C1.25 4.85 3.35 2.75 7 2.75H17C20.65 2.75 22.75 4.85 22.75 8.5V15.5C22.75 19.15 20.65 21.25 17 21.25ZM7 4.25C4.14 4.25 2.75 5.64 2.75 8.5V15.5C2.75 18.36 4.14 19.75 7 19.75H17C19.86 19.75 21.25 18.36 21.25 15.5V8.5C21.25 5.64 19.86 4.25 17 4.25H7Z"
                  fill="currentcolor"
                ></path>
                <path
                  d="M11.9998 12.87C11.1598 12.87 10.3098 12.61 9.65978 12.08L6.52978 9.57997C6.20978 9.31997 6.14978 8.84997 6.40978 8.52997C6.66978 8.20997 7.13978 8.14997 7.45978 8.40997L10.5898 10.91C11.3498 11.52 12.6398 11.52 13.3998 10.91L16.5298 8.40997C16.8498 8.14997 17.3298 8.19997 17.5798 8.52997C17.8398 8.84997 17.7898 9.32997 17.4598 9.57997L14.3298 12.08C13.6898 12.61 12.8398 12.87 11.9998 12.87Z"
                  fill="currentcolor"
                ></path>
              </svg>
            </div>
            <div class="detail">
              <div class="name">Email</div>
              <div class="value">chamsockhachhang@yody.vn</div>
            </div>
          </div>
        </div>
        <div class="infor-icons flex flex-wrap items-center">
          <div class="pr-3">
            <a
              class="hover:text-white"
              href="https://www.facebook.com/yody.vn"
              target="_blank"
              ><svg
                width="32"
                height="32"
                viewBox="0 0 32 32"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":ram:"
              >
                <path
                  d="M29.3337 21.5865C29.3337 26.4398 26.4403 29.3332 21.587 29.3332H20.0003C19.267 29.3332 18.667 28.7332 18.667 27.9998V20.3065C18.667 19.9465 18.9603 19.6399 19.3203 19.6399L21.667 19.5999C21.8537 19.5865 22.0137 19.4532 22.0537 19.2665L22.5203 16.7198C22.5603 16.4798 22.3737 16.2532 22.1203 16.2532L19.2803 16.2932C18.907 16.2932 18.6137 15.9999 18.6003 15.6399L18.547 12.3732C18.547 12.1598 18.7203 11.9732 18.947 11.9732L22.147 11.9198C22.3736 11.9198 22.547 11.7465 22.547 11.5199L22.4937 8.31982C22.4937 8.09316 22.3203 7.91984 22.0937 7.91984L18.4937 7.97319C16.2803 8.01319 14.5203 9.8265 14.5603 12.0398L14.627 15.7065C14.6403 16.0798 14.347 16.3732 13.9737 16.3865L12.3737 16.4132C12.147 16.4132 11.9737 16.5865 11.9737 16.8132L12.0137 19.3465C12.0137 19.5732 12.187 19.7465 12.4137 19.7465L14.0137 19.7198C14.387 19.7198 14.6803 20.0132 14.6936 20.3732L14.8136 27.9732C14.827 28.7199 14.227 29.3332 13.4803 29.3332H10.4137C5.56032 29.3332 2.66699 26.4398 2.66699 21.5732V10.4132C2.66699 5.55983 5.56032 2.6665 10.4137 2.6665H21.587C26.4403 2.6665 29.3337 5.55983 29.3337 10.4132V21.5865V21.5865Z"
                  fill="currentcolor"
                ></path></svg
            ></a>
          </div>
          <div class="pr-3">
            <a
              class="hover:text-white"
              href="https://www.instagram.com/yody.official/"
              target="_blank"
              ><svg
                width="28"
                height="28"
                viewBox="0 0 27 28"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":ran:"
                class="text-yd-typo-title"
              >
                <rect y="0.5" width="27" height="27" rx="6" fill="white"></rect>
                <circle
                  cx="13.5"
                  cy="14.4922"
                  r="6.5"
                  fill="currentcolor"
                ></circle>
                <circle
                  cx="21.75"
                  cy="6.49219"
                  r="2"
                  fill="currentcolor"
                ></circle></svg
            ></a>
          </div>
          <div class="pr-3">
            <a
              class="hover:text-white"
              href="https://zalo.me/3261263076513595338"
              target="_blank"
              ><svg
                xmlns="http://www.w3.org/2000/svg"
                width="32"
                height="32"
                viewBox="2 2 31 32"
                fill="none"
              >
                <g filter="url(#filter0_d_18122_7185)">
                  <path
                    d="M9.0055 4.63549C9.93 4.4897 10.8702 4.48882 11.8043 4.50978L11.724 4.58398C10.5018 5.38451 9.48826 6.4836 8.75583 7.74507C7.28746 10.2706 6.75232 13.2571 6.87366 16.152C6.99413 18.509 7.55983 20.8792 8.75932 22.9281C8.9601 23.2948 9.29446 23.6186 9.2997 24.0639C9.33724 25.0189 8.86495 25.919 8.22592 26.6016C8.26782 26.6453 8.30886 26.6889 8.35076 26.7326C8.94876 27.3856 9.58691 27.9993 10.1945 28.6436C11.0579 29.6196 12.0418 30.4838 12.8877 31.4773C11.4804 31.4982 10.0566 31.5637 8.66591 31.3009C6.91556 30.9613 5.36164 29.7479 4.6196 28.1259C4.17001 27.1883 4.03557 26.1398 4.00065 25.1123C3.99978 20.3685 3.99978 15.6255 4.00065 10.8826C4.01986 9.29725 4.43977 7.63857 5.55545 6.46265C6.43891 5.46657 7.68991 4.81881 9.0055 4.63549Z"
                    fill="#394960"
                  ></path>
                  <path
                    d="M21.8226 13.3457C22.1971 13.3457 22.5717 13.3457 22.947 13.3457C22.9409 15.5395 22.9409 17.7342 22.947 19.928C22.5804 19.8765 21.9702 20.1114 21.8322 19.6234C21.8095 17.5317 21.8305 15.4383 21.8226 13.3457Z"
                    fill="#1C2430"
                  ></path>
                  <path
                    d="M10.3657 13.4244C12.1082 13.4227 13.8489 13.4113 15.5905 13.4236C15.5783 13.7649 15.5591 14.1368 15.3304 14.4127C14.1396 15.895 12.9742 17.3965 11.7843 18.8789C13.0492 18.8867 14.3142 18.8815 15.5792 18.8815C15.5556 19.1774 15.6595 19.5223 15.4674 19.7789C15.347 19.9448 15.1287 19.93 14.948 19.9317C13.3653 19.923 11.7825 19.9396 10.2007 19.923C10.205 19.5886 10.2085 19.2185 10.4425 18.9522C11.6193 17.476 12.81 16.0102 13.9816 14.5305C12.7777 14.5323 11.573 14.5227 10.3692 14.5358C10.3613 14.1656 10.3639 13.7946 10.3657 13.4244Z"
                    fill="#1C2430"
                  ></path>
                  <path
                    d="M25.7347 14.8771C26.9883 14.5969 28.3484 15.4201 28.6915 16.6546C29.1219 17.9387 28.3362 19.4656 27.038 19.8567C25.9355 20.2452 24.6155 19.738 24.0437 18.7218C23.595 17.971 23.5679 16.988 23.9756 16.2154C24.3213 15.5336 24.9891 15.0352 25.7347 14.8771ZM25.7137 15.9893C24.949 16.2591 24.5369 17.1897 24.8355 17.9413C25.0825 18.652 25.9145 19.0867 26.6373 18.8685C27.4623 18.6712 27.9608 17.7048 27.6683 16.913C27.4239 16.129 26.4767 15.6768 25.7137 15.9893Z"
                    fill="#1C2430"
                  ></path>
                  <path
                    d="M16.4479 15.7912C17.0511 15.0439 18.1074 14.6755 19.038 14.9418C19.3453 15.0195 19.6238 15.1731 19.8927 15.3364C19.8901 15.2543 19.884 15.0911 19.8813 15.009C20.2332 15.0072 20.5841 15.0081 20.9359 15.0064C20.9342 16.6476 20.9324 18.2888 20.9368 19.9309C20.6784 19.9239 20.4156 19.9545 20.1616 19.9021C19.9835 19.8296 19.9285 19.635 19.8578 19.4761C18.887 20.2303 17.3619 20.0592 16.5552 19.1408C15.6954 18.2513 15.6508 16.7358 16.4479 15.7912ZM17.8691 16.0112C17.0607 16.2958 16.6687 17.3373 17.0782 18.088C17.4274 18.8196 18.4104 19.1269 19.1131 18.7236C19.7652 18.3813 20.0664 17.5319 19.7862 16.8527C19.5147 16.1142 18.5989 15.7004 17.8691 16.0112Z"
                    fill="#1C2430"
                  ></path>
                  <path
                    d="M11.7239 4.58335C11.9194 4.52748 12.1237 4.51002 12.3262 4.50391C15.8173 4.517 19.3084 4.50216 22.7995 4.50827C23.7327 4.51962 24.6712 4.45676 25.5974 4.59906C26.8798 4.69684 28.1142 5.23984 29.0684 6.09798C30.2662 7.24247 30.9052 8.89068 30.9253 10.5345C30.9261 15.1622 30.9235 19.7934 30.9279 24.4194C30.9157 24.4465 30.8921 24.5023 30.8799 24.5303C29.6359 25.9218 27.9632 26.8638 26.2146 27.4731C23.8584 28.2763 21.3346 28.5347 18.8579 28.3461C16.3813 28.1331 13.8854 27.4862 11.785 26.1174C10.7112 26.5949 9.52656 26.8289 8.35064 26.732C8.30874 26.6883 8.26771 26.6447 8.2258 26.601C8.86483 25.9183 9.33712 25.0183 9.29958 24.0632C9.29434 23.618 8.95999 23.2941 8.7592 22.9275C7.55971 20.8786 6.99402 18.5084 6.87354 16.1513C6.7522 13.2565 7.28734 10.27 8.75571 7.74444C9.48815 6.48297 10.5017 5.38388 11.7239 4.58335ZM21.8226 13.3455C21.8305 15.4381 21.8095 17.5315 21.8322 19.6232C21.9701 20.1112 22.5804 19.8764 22.947 19.9279C22.9409 17.7341 22.9409 15.5394 22.947 13.3455C22.5716 13.3455 22.1971 13.3455 21.8226 13.3455ZM10.3655 13.4232C10.3638 13.7934 10.3611 14.1644 10.369 14.5345C11.5728 14.5215 12.7776 14.5311 13.9814 14.5293C12.8099 16.009 11.6191 17.4748 10.4423 18.951C10.2084 19.2173 10.2049 19.5874 10.2005 19.9218C11.7824 19.9384 13.3651 19.9218 14.9478 19.9305C15.1285 19.9287 15.3468 19.9436 15.4672 19.7777C15.6593 19.5211 15.5554 19.1762 15.579 18.8803C14.314 18.8803 13.0491 18.8855 11.7841 18.8777C12.974 17.3953 14.1394 15.8938 15.3302 14.4115C15.5589 14.1356 15.5781 13.7637 15.5903 13.4224C13.8487 13.4101 12.108 13.4215 10.3655 13.4232ZM25.7345 14.8759C24.9889 15.0339 24.3211 15.5324 23.9754 16.2142C23.5677 16.9868 23.5948 17.9698 24.0435 18.7205C24.6153 19.7367 25.9353 20.2439 27.0378 19.8554C28.336 19.4643 29.1217 17.9375 28.6913 16.6533C28.3482 15.4189 26.9881 14.5957 25.7345 14.8759ZM16.4476 15.7899C15.6506 16.7345 15.6951 18.25 16.555 19.1396C17.3616 20.0579 18.8867 20.2291 19.8575 19.4748C19.9282 19.6337 19.9832 19.8284 20.1613 19.9008C20.4153 19.9532 20.6781 19.9226 20.9365 19.9296C20.9322 18.2875 20.9339 16.6463 20.9356 15.0051C20.5838 15.0068 20.2329 15.006 19.8811 15.0077C19.8837 15.0898 19.8898 15.253 19.8924 15.3351C19.6235 15.1718 19.3451 15.0182 19.0378 14.9405C18.1072 14.6742 17.0508 15.0426 16.4476 15.7899Z"
                    fill="white"
                  ></path>
                  <path
                    d="M17.8685 16.0106C18.5983 15.6998 19.5141 16.1136 19.7856 16.8521C20.0658 17.5313 19.7646 18.3807 19.1125 18.7229C18.4097 19.1263 17.4267 18.819 17.0775 18.0874C16.6681 17.3366 17.0601 16.2952 17.8685 16.0106Z"
                    fill="white"
                  ></path>
                  <path
                    d="M25.7132 15.9885C26.4762 15.676 27.4234 16.1282 27.6678 16.9121C27.9603 17.7039 27.4618 18.6703 26.6368 18.8676C25.914 19.0859 25.0821 18.6511 24.835 17.9405C24.5364 17.1889 24.9485 16.2583 25.7132 15.9885Z"
                    fill="white"
                  ></path>
                  <path
                    d="M30.8798 24.5302L30.9488 24.4551C30.9846 25.8196 30.837 27.2434 30.1674 28.4577C29.3887 29.8825 27.9762 30.9405 26.3874 31.2792C25.4961 31.4634 24.5821 31.5045 23.6742 31.4931C20.8815 31.494 18.0888 31.4931 15.2961 31.494C14.4929 31.4809 13.688 31.5184 12.8875 31.4765C12.0416 30.4831 11.0577 29.6188 10.1943 28.6428C9.58674 27.9985 8.94858 27.3848 8.35059 26.7318C9.5265 26.8287 10.7111 26.5948 11.7849 26.1172C13.8853 27.4861 16.3812 28.133 18.8579 28.346C21.3345 28.5346 23.8584 28.2762 26.2146 27.473C27.9632 26.8637 29.6358 25.9217 30.8798 24.5302Z"
                    fill="#394960"
                  ></path>
                </g>
                <defs>
                  <filter
                    id="filter0_d_18122_7185"
                    x="0"
                    y="0.5"
                    width="34.9536"
                    height="35"
                    filterUnits="userSpaceOnUse"
                    color-interpolation-filters="sRGB"
                  >
                    <feFlood
                      flood-opacity="0"
                      result="BackgroundImageFix"
                    ></feFlood>
                    <feColorMatrix
                      in="SourceAlpha"
                      type="matrix"
                      values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 127 0"
                      result="hardAlpha"
                    ></feColorMatrix>
                    <feOffset></feOffset>
                    <feGaussianBlur stdDeviation="2"></feGaussianBlur>
                    <feComposite in2="hardAlpha" operator="out"></feComposite>
                    <feColorMatrix
                      type="matrix"
                      values="0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0.25 0"
                    ></feColorMatrix>
                    <feBlend
                      mode="normal"
                      in2="BackgroundImageFix"
                      result="effect1_dropShadow_18122_7185"
                    ></feBlend>
                    <feBlend
                      mode="normal"
                      in="SourceGraphic"
                      in2="effect1_dropShadow_18122_7185"
                      result="shape"
                    ></feBlend>
                  </filter>
                </defs></svg
            ></a>
          </div>
          <div class="pr-3">
            <a
              class="hover:text-white"
              href="https://www.youtube.com/@YODYLifestyle"
              target="_blank"
              ><svg
                width="32"
                height="32"
                viewBox="0 0 33 32"
                fill="none"
                xmlns="http://www.w3.org/2000/svg"
                id=":rap:"
              >
                <path
                  d="M23.6211 5.3335H10.2878C6.28776 5.3335 3.62109 8.00016 3.62109 12.0002V20.0002C3.62109 24.0002 6.28776 26.6668 10.2878 26.6668H23.6211C27.6211 26.6668 30.2878 24.0002 30.2878 20.0002V12.0002C30.2878 8.00016 27.6211 5.3335 23.6211 5.3335ZM19.4744 17.3735L16.1811 19.3468C14.8477 20.1468 13.7544 19.5335 13.7544 17.9735V14.0135C13.7544 12.4535 14.8477 11.8402 16.1811 12.6402L19.4744 14.6135C20.7411 15.3868 20.7411 16.6135 19.4744 17.3735Z"
                  fill="currentcolor"
                ></path></svg
            ></a>
          </div>
        </div>
      </div>
    </div>
    <div class="company-infor">
      <div class="infor">
        <div class="title">@ CÔNG TY CỔ PHẦN THỜI TRANG YODY</div>
        <div class="detail">
          Mã số doanh nghiệp: 0801206940. Giấy chứng nhận đăng ký doanh nghiệp
          do Sở Kế hoạch và Đầu tư TP Hải Dương cấp lần đầu ngày 04/03/2017
        </div>
      </div>
      <div class="icons">
        <div class="icon">
          <img
            src="	https://yody.vn/images/identity-badge/bct_v1.png"
            loading="lazy"
            width="105"
            alt="dmca"
          />
        </div>
        <div class="icon">
          <img
            src="https://yody.vn/images/identity-badge/dmca_v1.png"
            width="80"
            loading="lazy"
            alt="dmca"
          />
        </div>
      </div>
    </div>
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
      currGoiYId: 0,
      swiper: null,
      GoiYs: ["Áo Giữ Nhiệt", "Áo Thun", "Áo Polo", "Đồ Lót"],
      isShowGoiY: false,
    };
  },
  methods: {
    changeGoiY(i) {
      this.currGoiYId = i;
    },
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
