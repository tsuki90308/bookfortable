import { createRouter, createWebHistory } from 'vue-router';
import Home from './components/Home.vue';
import About from './components/About.vue';
import Contact from './components/Contact.vue';
import WishList from './components/WishList.vue';
import Create from './components/Create.vue'
import AllWishList from './components/AllWishList.vue';
import WishList2 from './components/WishList2.vue';

const routes = [
  {
    path:"/",
    component : Home,
  },
  {
    path:"/about",
    component : About,
  },
  {
    path:"/contact",
    component : Contact,
  },
  {
    path:"/wishlist",
    component : WishList,
  },
  {
    path:"/create",
    component : Create,
  },
  {
    path:"/allwishlist",
    component : AllWishList,
  },
  {
    path:"/wishlist2",
    component : WishList2,
  }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;