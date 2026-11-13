import {ErrorBoundary, Route, Router as Routes} from "preact-iso";
import HashLocationProvider from "../providers/HashLocationProvider.jsx";
import MasterLayout from "../layouts/MasterLayout.jsx";
import HomeRedirector from "../redirector/HomeRedirector.jsx";
import HomePage from "../features/home/pages/HomePage.jsx";
import KnowledgePage from "../features/knowledge/pages/KnowledgePage.jsx";
import SettingPage from "../features/setting/pages/SettingPage.jsx";

const Router = () => {

    const handleChange = (route) => {

        window.chrome.webview.postMessage({
            method: 'route-change',
            data: {
                route
            }
        });
    }

    return <>
        <MasterLayout>
            <HashLocationProvider>
                <ErrorBoundary>
                    <Routes onRouteChange={handleChange}>
                        <Route path="/" component={HomeRedirector} />

                        <Route path="/new" component={HomePage} />
                        <Route path="/chats/:id" component={HomePage} />

                        <Route path="/knowledges" component={KnowledgePage} />

                        <Route path="/settings" component={SettingPage} />
                    </Routes>
                </ErrorBoundary>
            </HashLocationProvider>
        </MasterLayout>
    </>
}

export default Router