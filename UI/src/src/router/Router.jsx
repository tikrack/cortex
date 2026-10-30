import {LocationProvider, Route, Router as Routes} from "preact-iso";

const Router = () => {
    return <>
        <LocationProvider>
            <Routes>
                <Route path="/" component={<>Homeeeeeeee</>} />
            </Routes>
        </LocationProvider>
    </>
}

export default Router