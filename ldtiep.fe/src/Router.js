import { createRouter, createWebHistory } from 'vue-router'
import YodyHome from './components/YodyHome.vue'
import ProductsView from './components/products-view/ProductsView.vue'
import ProductCart from './components/product-cart/ProductCart.vue'
import ProductBuy from './components/product-buy/ProductBuy.vue'
import ProductDetail from './components/product-detail/ProductDetail.vue'
import ProductManage from '/src/components/product-manage/ProductManage.vue'
import LoginPage from './components/login-page/LoginPage.vue'
const routes = [
  {
    path: '/',
    name: 'YodyHome',
    component: YodyHome
  },
  {
    path: '/tim-kiem-san-pham',
    name: 'ProductsView',
    component: ProductsView
  },
  {
    path: '/thong-tin-chi-tiet',
    name: 'ProductDetail',
    component: ProductDetail
  },
  {
    path: '/gio-hang',
    name: 'ProductCart',
    component: ProductCart
  },
  {
    path: '/mua-hang',
    name: 'ProductBuy',
    component: ProductBuy
  },
  {
    path: '/admin',
    name: 'ProductManage',
    component: ProductManage
  },
  {
    path: '/login',
    name: 'LoginPage',
    component: LoginPage
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router;