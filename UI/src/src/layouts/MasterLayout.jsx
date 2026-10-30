import SideBar from "./partials/SideBar.jsx";

const MasterLayout = ({ children }) => {
    return <div class={'flex h-dvh'}>
        <SideBar />
        {children}
    </div>
}

export default MasterLayout