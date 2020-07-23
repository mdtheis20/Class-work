<template>
  <div>
      <p>Average rating is <strong>{{averageRating}}</strong> from <strong>{{count}}</strong> reviews</p>
  </div>  
</template>

<script>
export default {
    props: {
        reviewsInChild : Array
    },
    computed: {
        count(){
            return this.reviewsInChild.length;
        },
        averageRating(){
            let sum = this.reviewsInChild.reduce( (accum, review) => review.rating + accum, 0);
            return (sum / this.reviewsInChild.length).toFixed(2);
        }
    },
}
</script>

<style scoped>
    p {
        border: 1px solid blue;
        border-radius: 5px;
    }
</style>