<template>
  <div class="picture-cell">
    <img height="60px" :src="src" />
  </div>
</template>
      
<script>
import API from "/src/service/api.js";
export default {
  name: "PictureComponent",
  props: ["ids"],
  components: {},
  computed: {
    src() {
      return this.api.baseUrl + "/" + this.ids.split(";")[0];
    },
  },
  data() {
    return {
      api: new API("Pictures"),
    };
  },
};
</script>
      
      <style  lang="scss">
</style>
      