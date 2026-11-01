import {IconSearch, IconLayoutSidebar, IconEdit, IconLibrary} from '@tabler/icons-preact';

const SideBar = () => {
    const ITEMS = [
        {
            title: "New chat",
            icon: <IconEdit stroke={1.5} size={20} />,
            url: "/new"
        },
        {
            title: "Knowledge",
            icon: <IconLibrary stroke={1.5} size={20} />,
            url: "/knowledge"
        },
    ]

    return <>
        <aside className={"px-2 w-85 border-e border-gray-200"}>
            <div className={"h-14 flex items-center justify-between mb-2"}>
                <div className={"flex items-center gap-2.5"}>
                    <img src="/logo/logo.svg" alt="cortex logo" className={"h-10 ml-2"}/>
                    <h3 className={"font-semibold text-xl text-gray-900"}>Cortex</h3>
                </div>
                <div className={"flex items-center justify-end gap-2"}>
                    <button className={"t-action-button"}>
                        <IconSearch stroke={1.5} size={20} />
                    </button>
                    <button className={"t-action-button"}>
                        <IconLayoutSidebar stroke={1.5} size={20} />
                    </button>
                </div>
            </div>
            <div className={"flex flex-col gap-2"}>
                { ITEMS.map((item, index) => (
                    <a href={item.url} class="h-9 rounded-lg flex items-center px-2.5 hover:bg-gray-100 gap-2 cursor-pointer">
                        {item.icon}
                        <span className={"text-[14px]"}>{item.title}</span>
                    </a>
                )) }
            </div>
        </aside>
    </>
}

export default SideBar;