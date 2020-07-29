<template>
  <div>
    <h1>Best Sellers</h1>
    <best-seller-list/>
    <h2>New Releases</h2>
    <new-releases-list/>
  </div>
</template>


<script>
import BestSellerList from "@/components/BestSellerList.vue";
import NewReleasesList from "@/components/NewReleasesList.vue";
export default {
  components: {
    BestSellerList,
    NewReleasesList
  },
};
</script>

<style scoped>
</style>