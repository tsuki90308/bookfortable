import { createRouter, createWebHistory } from 'vue-router';
import Home from './components/Home.vue';
import About from './components/About.vue';
import Contact from './components/Contact.vue';
import WishList from './components/WishList.vue';

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
  }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;