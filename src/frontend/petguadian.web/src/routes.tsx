import { createBrowserRouter } from "react-router-dom";
import { Home } from './Pages/home'
import { SideBar } from "./Components/SideBar";
import { MyPets } from "./Pages/system/mypets";
import { Login } from "./Pages/login/login";
import { Singup } from "./Pages/singup/singup";
import SimpleSidebar from "./Components/ChakraSideBar/SimpleSideBar";



const router = createBrowserRouter([
    {
        path: "/",
        element: <Home/>
    },
    {
        path:"/login",
        element: <Login/>
    },
    {
        path:"/singup",
        element: <Singup/>
    },
    
    {
        element: <SideBar/>,
        children: [
            {
                path: "/mypets",
                element: <MyPets/>
            }
        ],        
    }
])



export { router };