<template>
    <div>
        <h1>Reading List</h1>
        <reading-list />
<router-link :to="{name: 'addBook'}"> Add a New Book</router-link>
        
    </div>
</template>

<script>
import ReadingList from "@/components/ReadingList.vue";

export default {
  components: {
    ReadingList
    
  },
};
</script>

<style scoped>
</style>