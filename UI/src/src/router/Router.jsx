import {ErrorBoundary, Route, Router as Routes} from "preact-iso";
import HashLocationProvider from "../providers/HashLocationProvider.jsx";
import MasterLayout from "../layouts/MasterLayout.jsx";
import HomeRedirector from "../redirector/HomeRedirector.jsx";
import HomePage from "../features/home/pages/HomePage.jsx";
import KnowledgePage from "../features/knowledge/pages/KnowledgePage.jsx";

const Router = () => {
    return <>
        <MasterLayout>
            <HashLocationProvider>
                <ErrorBoundary>
                    <Routes>
                        <Route path="/" component={HomeRedirector} />

                        <Route path="/new" component={HomePage} />
                        <Route path="/chat/:id" component={HomePage} />

                        <Route path="/knowledge" component={KnowledgePage} />
                    </Routes>
                </ErrorBoundary>
            </HashLocationProvider>
        </MasterLayout>
    </>
}

export default Router