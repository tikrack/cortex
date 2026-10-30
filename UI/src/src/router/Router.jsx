import {LocationProvider, Route, Router as Routes} from "preact-iso";
import HomePage from "../features/home/pages/HomePage.jsx";

const Router = () => {
    return <>
        <LocationProvider>
            <Routes>
                <Route path="/" component={HomePage} />
            </Routes>
        </LocationProvider>
    </>
}

export default Router