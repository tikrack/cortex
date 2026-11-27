import {useRoute} from "preact-iso";
import {useState} from "preact/hooks";

const HomePage = () => {
    const { params } = useRoute();

    const [conversation, setConversation] = useState({
        
    });

    return <>
        <header className={"h-13 flex items-center justify-between border-b border-gray-100"}>
            <div></div>
            <div></div>
        </header>
    </>
}

export default HomePage;