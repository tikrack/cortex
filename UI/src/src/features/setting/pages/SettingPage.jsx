import {useEffect} from "preact/hooks";

const SettingPage = () => {
    useEffect(() => {
        
    }, []);

    return <>
        <section className={"max-w-3xl mx-auto mt-2"}>
            <div className={"flex flex-col gap-1 w-full mb-8"}>
                <h1 className={"m-0 wrap-break-word  text-[24px] tracking-[0.8px] text-[#0d0d0d]"}>Settings</h1>
                <p className={"text-base text-gray-600 text-balance font-light"}>Review your app settings</p>
            </div>


        </section>
    </>
}

export default SettingPage