import {LocationProvider, Route, Router as Routes} from "preact-iso";
import HomePage from "../features/home/pages/HomePage.jsx";
import HashLocationProvider from "../providers/HashLocationProvider.jsx";

const Router = () => {
    return <>
        <HashLocationProvider>
            <Routes>
                <Route path="/" component={HomePage} />
            </Routes>
        </HashLocationProvider>
    </>
}

export default Router