import {ErrorBoundary, LocationProvider, Route, Router as Routes} from "preact-iso";
import HomePage from "../features/home/pages/HomePage.jsx";
import HashLocationProvider from "../providers/HashLocationProvider.jsx";
import MasterLayout from "../layouts/MasterLayout.jsx";

const Router = () => {
    return <>
        <MasterLayout>
            <HashLocationProvider>
                <ErrorBoundary>
                    <Routes>
                        <Route path="/" component={HomePage} />
                    </Routes>
                </ErrorBoundary>
            </HashLocationProvider>
        </MasterLayout>
    </>
}

export default Router