import SideBar from "./partials/SideBar.jsx";

const MasterLayout = ({ children }) => {
    return <div className={'flex h-dvh'}>
        <SideBar />
        <main className={"px-6 w-full h-full"}>
            {children}
        </main>
    </div>
}

export default MasterLayout