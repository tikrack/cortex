import SideBar from "./partials/SideBar.jsx";

const MasterLayout = ({ children }) => {
    return (
      <div className={"flex h-dvh"}>
        <SideBar />
        <main className={"px-6 w-full max-h-full overflow-hidden overflow-y-auto"}>{children}</main>
      </div>
    );
}

export default MasterLayout