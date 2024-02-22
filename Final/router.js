import { createWebHistory, createRouter } from 'vue-router'
import Home from './views/Home.vue';
import About from './views/About.vue'
import Contact from './views/Contact.vue';
import Spots from './views/Spots.vue';

const routes = [
    {
        path: '/',
        component: Home
    },
    {
        path: '/about',
        component: About
    },
    {
        path: '/contact',
        component: Contact
    },
    {
        path: '/spots',
        component: Spots
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router;