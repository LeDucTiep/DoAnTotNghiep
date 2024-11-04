import { createApp } from 'vue'
import App from './App.vue'
import router from '/src/Router.js'
import Vuesax from 'vuesax3'
import 'vuesax3/dist/vuesax.css'
import "material-icons/iconfont/material-icons.css";

createApp(App)
    .use(router)
    .use(Vuesax)
    .mount('#app')
