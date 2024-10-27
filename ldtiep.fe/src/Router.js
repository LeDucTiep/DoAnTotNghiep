import { createRouter, createWebHashHistory } from 'vue-router'
import YodyHome from './components/YodyHome.vue'

const routes = [
  {
    path: '/',
    name: 'YodyHome',
    component: YodyHome
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router;