import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import  ProjectAdd  from "./components/Project/ProjectAdd";
import ProjectList  from "./components/Project/ProjectList";
import  ProjectUsers  from "./components/ProjectUsers/ProjectUsers";
import UserAdd  from "./components/User/UserAdd";
import UserList  from "./components/User/UserList";
import TicketAdd  from "./components/Ticket/TicketAdd";
import  TicketList  from "./components/Ticket/TicketList";
const AppRoutes = [
 
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/user-list',
        element: <UserList />
    },
    {
        path: '/user-add',
        element: <UserAdd />
    },
    {
        path: '/project-list',
        element: <ProjectList />
    },
    {
        path: '/project-add',
        element: <ProjectAdd />
    },
    {
        path: '/ticket-list',
        element: <TicketList />
    },
    {
        path: '/ticket-add',
        element: <TicketAdd />
    },
    {
        path: '/project-users',
        element: <ProjectUsers />
    }
];  

export default AppRoutes;