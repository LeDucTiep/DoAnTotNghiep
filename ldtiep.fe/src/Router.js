import { createRouter, createWebHistory } from 'vue-router'
import YodyHome from './components/YodyHome.vue'
import ProductsView from './components/products-view/ProductsView.vue'

const routes = [
  {
    path: '/',
    name: 'YodyHome',
    component: YodyHome
  },
  {
    path: '/ao-nam',
    name: 'ProductsView',
    component: ProductsView
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router;