const SideBar = () => {
    return <>
        <aside className={"px-5 w-85 border-e border-gray-200"}>
            <div className={"h-14 flex items-center justify-between"}>
                <div className={"flex items-center gap-2.5"}>
                    <img src="../../../public/logo/logo.svg" alt="cortex logo" className={"h-10"}/>
                    <h3 className={"font-semibold text-xl text-gray-900"}>Cortex</h3>
                </div>
            </div>
        </aside>
    </>
}

export default SideBar;