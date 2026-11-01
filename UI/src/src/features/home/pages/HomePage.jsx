import {useRoute} from "preact-iso";

const HomePage = () => {
    const { params } = useRoute();

    return <>
        {params.id ? "Chat" : "Home"}
    </>
}

export default HomePage;