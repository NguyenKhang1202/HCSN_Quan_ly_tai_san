import { createRouter, createWebHistory} from "vue-router";
import TheEmployee from "./views/Employee/Employee.vue"
import TheCustomer from "./views/Customer/Customer.vue"
import TheReport from "./views/Report/Report.vue"
import TheSetting from "./views/Setting/Setting.vue"
import HomePage from "./views/HomePage.vue"

const routes = [
    {
        path: "/",
        component: HomePage,
    },
    {
        path: "/report",
        component: TheReport,
    },
    {
        path: "/employee",
        component: TheEmployee,
    },
    {
        path: "/customer",
        component: TheCustomer,
    },
    {
        path: "/setting",
        component: TheSetting,
    },
    
];
const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes: routes,
})

export default router;
