import {ErrorBoundary, LocationProvider, Route, Router as Routes} from "preact-iso";
import HomePage from "../features/home/pages/HomePage.jsx";
import HashLocationProvider from "../providers/HashLocationProvider.jsx";

const Router = () => {
    return <>
        <HashLocationProvider>
            <ErrorBoundary>
                <Routes>
                    <Route path="/" component={HomePage} />
                </Routes>
            </ErrorBoundary>
        </HashLocationProvider>
    </>
}

export default Router