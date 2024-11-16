import { createApp } from 'vue'
import App from './App.vue'
import router from '/src/Router.js'
import Vuesax from 'vuesax3'
import 'vuesax3/dist/vuesax.css'
import "material-icons/iconfont/material-icons.css";
import PickColors from "vue-pick-colors";

createApp(App)
    .use(router)
    .use(Vuesax)
    .component('PickColors', PickColors)
    .mount('#app')
