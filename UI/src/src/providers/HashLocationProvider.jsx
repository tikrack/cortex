import { useEffect, useState } from "preact/hooks";
import { LocationProvider } from "preact-iso";

const HashLocationProvider = ({ children }) => {
    const [url, setUrl] = useState(window.location.hash.slice(1) || "/");

    useEffect(() => {
        const handleHashChange = () => {
            setUrl(window.location.hash.slice(1) || "/");
        };

        window.addEventListener("hashchange", handleHashChange);

        return () => {
            window.removeEventListener("hashchange", handleHashChange);
        };
    }, []);

    return (
        <LocationProvider url={url}>
            {children}
        </LocationProvider>
    );
};

export default HashLocationProvider;