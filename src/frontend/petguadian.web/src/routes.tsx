import { createBrowserRouter } from "react-router-dom";
import { Home } from './Pages/home'
import { SideBar } from "./Components/SideBar";
import { MyPets } from "./Pages/system/mypets";
import { Login } from "./Pages/login/login";
import { Singup } from "./Pages/singup/singup";
import SimpleSidebar from "./Components/ChakraSideBar/SimpleSideBar";
import { NotFound } from "./Pages/notFound/notFound";
import { PetDetails } from "./Components/PetDetails";
import CustomSideBar from "./Components/TestSideBar/CustomSideBar";



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
        path:"*",
        element: <NotFound/>
    },
    {
        element: <CustomSideBar/>,
        children: [
            {
                path: "/mypets",
                element: <MyPets/>
            },
            {
                path: "/pet-details/:id",
                element: <PetDetails/>
            }
        ],        
    }
])



export { router };