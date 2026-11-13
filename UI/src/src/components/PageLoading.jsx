import {IconLoader} from "@tabler/icons-preact";

const PageLoading = () => {
    return <>
        <div className={"w-full"}>
            <div className={"flex flex-col justify-center items-center gap-2"}>
                <div className={"animate-spin size-fit text-gray-600"}>
                    <IconLoader size={30}/>
                </div>
                <h4 className={"text-gray-500 text-lg"}>Loading. Please Wait</h4>
            </div>
        </div>
    </>
}

export default PageLoading;