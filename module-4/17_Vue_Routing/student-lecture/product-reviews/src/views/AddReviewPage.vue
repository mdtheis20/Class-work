<template>
  <div>
    <h1>Add Review</h1>
    <add-review :productId="productId"/>
  </div>
</template>

<script>
import AddReview from "@/components/AddReview";

export default {
  components: {
    AddReview
  },
  data(){
      return {
          productId: 0
      }
  },
  created(){
      this.productId = parseInt(this.$route.params.id)
  }
};
</script>

<style>
</style>