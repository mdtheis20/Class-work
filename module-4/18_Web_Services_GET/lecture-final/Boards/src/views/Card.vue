<template>
  <card-detail :cardId="$route.params.cardID" :boardId="$route.params.boardID"/>
</template>

<script>
import CardDetail from '@/components/CardDetail';
export default {
  components: {
    CardDetail
  }
};
</script>
