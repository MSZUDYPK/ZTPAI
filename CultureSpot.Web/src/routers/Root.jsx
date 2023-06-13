import App from "../App";
import AuthorizationPage from "../pages/login/AuthorizationPage";
import Main from "../pages/main/Main";
import Creator from "../pages/creator/creator";
import FirstStage from "../components/Stages/FirstStage/FirstStage";
import SecondStage from "../components/Stages/SecondStage/SecondStage";
import ThirdStage from "../components/Stages/ThirdStage/ThirdStage";
import EventDetails from "../components/EventDetails/EventDetails";



const Root = [
    {
        path: "/",
        element: <App  message={"Hello world!"}/>,
    },
    {
        path: "auth",
        element: <AuthorizationPage />,
    },
    {
        path: "events",
        element: <Main />,
    },
    {
        path: "events/:eventId",
        element: <EventDetails />,
    },
    {
        path: "creator/*",
        element: <Creator />,
        children: [
            {
                path: "1",
                element: <FirstStage />
            },
            {
                path: "2",
                element: <SecondStage />
            },
            {
                path: "3",
                element: <ThirdStage />
            },
            {
                path: "4",
                element: <ThirdStage />
            }
        ],
    },
];

export default Root;