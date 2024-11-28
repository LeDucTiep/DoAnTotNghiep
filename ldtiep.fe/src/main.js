import { createApp } from 'vue'
import App from './App.vue'
import router from '/src/Router.js'
import Vuesax from 'vuesax3'
import 'vuesax3/dist/vuesax.css'
import "material-icons/iconfont/material-icons.css";
import PickColors from "vue-pick-colors";
import TGrid from "/src/base/tgrid/TGrid";
import VueCookies from 'vue-cookies';

createApp(App)
    .use(router)
    .use(VueCookies)
    .use(Vuesax)
    .component('PickColors', PickColors)
    .component('TGrid', TGrid)
    .mount('#app')
