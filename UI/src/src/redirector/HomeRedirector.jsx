import {useLocation} from "preact-iso";
import {useEffect} from "preact/hooks";

const HomeRedirector = () => {
    const { route } = useLocation();

    useEffect(() => {
        route('/new');
    }, []);

    return <></>
}

export default HomeRedirector