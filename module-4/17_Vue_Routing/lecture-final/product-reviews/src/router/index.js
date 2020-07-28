import Vue from 'vue'
import VueRouter from 'vue-router'
import Products from '@/views/Products.vue'
import ProductDetail from '@/views/ProductDetail.vue'
import AddReviewPage from '@/views/AddReviewPage.vue'

Vue.use(VueRouter)

const routes = [
  // Add a route for the Home page, which is the Products view
  {
    path: "/",
    name: "products",
    component: Products
  },
  {
    path: "/product/:id",
    name: "product-detail",
    component: ProductDetail
  },
  {
    path: "/product/:id/add-review",
    name: "add-review",
    component: AddReviewPage
  }


]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
