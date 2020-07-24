<template>
  <div class="main">
    <h1>All-Time Home Run Leaders</h1>
    <bar-chart class="bar-chart" :chartData="chartData" />
  </div>
</template>

<script>
import BarChart from "./BarChart.vue";
export default {
  name: "MainPage",
  components: {
    BarChart,
  },
  data() {
    return {
      // defaultScale: 400,
      objectData: [
        { id: 1, homeRuns: 762, name: "Bonds" },
        { id: 2, homeRuns: 755, name: "Aaron" },
        { id: 3, homeRuns: 714, name: "Ruth" },
        { id: 4, homeRuns: 696, name: "Rodriguez" },
        { id: 5, homeRuns: 660, name: "Mays" },
        { id: 6, homeRuns: 656, name: "Pujols" },
        { id: 7, homeRuns: 630, name: "Griffey" },
        { id: 8, homeRuns: 612, name: "Thome" },
        { id: 9, homeRuns: 609, name: "Sosa" },
        { id: 10, homeRuns: 586, name: "Robinson" },
      ],
    };
  },
  computed: {
    chartData() {
      return this.objectData.slice(0, 8).map((e) => {
        return {
          id: e.id,
          value: e.homeRuns,
          label: `${e.name} (${e.homeRuns})`,
        };
      });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.bar-chart {
  width: 800px;
  height: 200px;
  border: 1px solid black;
  font-size: 0.8rem;
}

div.main {
  /* Keep the reviews narrow */
  max-width: 800px;
  margin: 60px auto 0 auto;
}
</style>
