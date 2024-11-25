<template>
  <div class="home-body">
    <div class="ontop-swiper">
      <div class="swiper-container">
        <swiper ref="mySwiper" :slides-per-view="1" @swiper="onSwiper">
          <swiper-slide>
            <img
              @click="toFilterPage({ q: 'sale-50%' })"
              loading="lazy"
              decoding="async"
              class="w-full cursor"
              src="../assets/images/swip1.png"
              style="color: transparent"
            />
          </swiper-slide>
          <swiper-slide
            ><img
              @click="toFilterPage({ q: 'sale-50%' })"
              loading="lazy"
              decoding="async"
              class="w-full cursor"
              src="../assets/images/swip2.png"
              style="color: transparent"
          /></swiper-slide>
          <swiper-slide
            ><img
              @click="toFilterPage({ q: 'sale-50%' })"
              loading="lazy"
              decoding="async"
              class="w-full cursor"
              src="../assets/images/swip3.png"
              style="color: transparent"
          /></swiper-slide>
          <swiper-slide
            ><img
              @click="toFilterPage({ q: 'sale-50%' })"
              loading="lazy"
              decoding="async"
              class="w-full cursor"
              src="../assets/images/swip4.png"
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
          v-for="(item, index) in TopCategories"
          :key="index"
          class="ua-chuong-b"
          :class="{ 'ua-chuong-b--active': currUaChuongId == index }"
          @click="changeUaChuong(index)"
        >
          <div class="b-block">
            {{ item.CategoryName }}
          </div>
        </div>
      </div>

      <div class="uacuong-products">
        <div class="product-row">
          <ProductSP
            v-for="(item, index) in TopProductDatas"
            :key="index"
            :productID="item.ProductID"
            :name="item.ProductName"
            :colors="item.ColorCodes.split(';')"
            :price="item.Price"
            :originalPrice="item.OriginalPrice"
            :discount="item.Discount"
            :pictureIds="item.PictureIDS"
            class="w-25"
          ></ProductSP>
        </div>
      </div>

      <div @click="toFilterPage({ q: 'ban-chay' })" class="view-more-product">
        <div class="button-view-more">Xem thêm</div>
      </div>
    </div>
    <div class="san-pham-tot">
      <img
        @click="toFilterPage({ q: 'ban-chay' })"
        loading="lazy"
        decoding="async"
        class="w-full h-full"
        src="../assets/images/sw5.png"
        style="color: transparent"
      />
    </div>
    <div class="goi-y">
      <div class="goi-y-title">
        <div class="left">Gợi ý sản phẩm</div>
        <div class="right">
          <TPop @open="isShowGoiY = true" @close="isShowGoiY = false">
            <div class="goi-y-show d-flex">
              <div class="goi-y-right">
                {{ TopCategories[currGoiYId]?.CategoryName }}
              </div>

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
                  v-for="(item, index) in TopCategories"
                  :key="index"
                  class="goi-y-item"
                  :class="{ 'goi-y-item--active': currGoiYId == index }"
                  @click="changeGoiY(index)"
                >
                  {{ item.CategoryName }}
                </div>
              </div>
            </template>
          </TPop>
        </div>
      </div>
      <div class="products-block">
        <div class="product-row">
          <ProductSP
            v-for="(item, index) in GoiYProductDatas"
            :key="index"
            :productID="item.ProductID"
            :name="item.ProductName"
            :colors="item.ColorCodes.split(';')"
            :price="item.Price"
            :originalPrice="item.OriginalPrice"
            :discount="item.Discount"
            :pictureIds="item.PictureIDS"
            class="w-25"
          ></ProductSP>
        </div>
      </div>
      <div @click="toFilterPage({ q: 'ban-chay' })" class="view-more-product">
        <div class="button-view-more">Xem thêm</div>
      </div>
    </div>
  </div>
  <div class="gioi-thieu">
    <div class="gioi-thieu-header">#Yody tự hào thương hiệu Việt</div>
    <div class="infor-tags">
      <div class="tags">
        <img
          src="../assets/images/sw6.png"
          loading="lazy"
          class="w-full h-full object-cover"
          alt="media"
        />
        <div class="title">
          YODY Cán Mốc 280 Cửa Hàng - Thương hiệu Thời trang Chinh Phục Mọi Miền
          Đất Nước
        </div>
        <div class="detail">
          Thương hiệu thời trang Việt Nam YODY vừa ghi dấu ấn mới trong hành
          trình phát triển của mình khi chính thức cán mốc 280 cửa hàng trên
          toàn quốc
        </div>
      </div>
      <div class="tags">
        <img
          src="../assets/images/sw7.png"
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
          chính là nguồn động lực to lớn để YODY tiếp tục lan tỏa những giá trị
          tốt đẹp đến cộng đồng.
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { Swiper, SwiperSlide } from "swiper/vue";
import "swiper/css";
import TPop from "/src/base/popover/TPop.vue";
import ProductSP from "/src/components/cloth/ProductSP.vue";
import API from "/src/service/api.js";
export default {
  name: "YodyHome",
  components: {
    TPop,
    Swiper,
    SwiperSlide,
    ProductSP,
  },
  props: {},
  data() {
    return {
      CateApi: new API("Categorys"),
      ProductApi: new API("Products"),
      currUaChuongId: 0,
      currGoiYId: 0,
      swiper: null,
      isShowGoiY: false,
      TopCategories: [],
      TopProductDatas: [],
      GoiYProductDatas: [],
    };
  },
  async created() {
    await this.getTopCategory();
    await this.getTopProduct();
    await this.getGoiYProduct();
  },
  methods: {
    buildProductParam() {
      const cate = this.TopCategories[this.currUaChuongId];
      const search = {};

      if (cate?.CategoryID) {
        search.CategoryIDs = [cate.CategoryID];
      }

      const param = {
        PageSize: 4,
        PageNumber: 1,
        SearchIn: search,
      };
      return param;
    },
    async getTopProduct() {
      const param = this.buildProductParam();

      const res = await this.ProductApi.paging(param);

      this.TopProductDatas = res.Data;
    },
    async getGoiYProduct() {
      const cate = this.TopCategories[this.currGoiYId];
      const search = {};

      if (cate?.CategoryID) {
        search.CategoryIDs = [cate.CategoryID];
      }

      const param = {
        PageSize: 8,
        PageNumber: 1,
        SearchIn: search,
      };

      const res = await this.ProductApi.paging(param);

      this.GoiYProductDatas = res.Data;
    },

    async getTopCategory() {
      const param = {
        PageSize: 5,
        PageNumber: 1,
        Sorter: {
          SoldCount: "desc",
        },
        SearchEquals: {
          ParentID: null,
        },
      };

      let res = await this.CateApi.paging(param);

      this.TopCategories = res.Data;
    },
    toFilterPage(query) {
      const p = "/tim-kiem-san-pham";

      this.$router.push({
        path: p,
        query: query,
      });
    },
    changeGoiY(i) {
      this.currGoiYId = i;

      this.getGoiYProduct();
    },
    changeUaChuong(i) {
      this.currUaChuongId = i;

      this.getTopProduct();
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
