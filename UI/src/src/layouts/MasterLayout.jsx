import SideBar from "./partials/SideBar.jsx";
import { Toaster } from "@preachjs/toast";

const MasterLayout = ({ children }) => {
    return (
      <div className={"flex h-dvh"}>
        <SideBar />
        <main className={"px-6 w-full h-full"}>{children}</main>
      </div>
    );
}

export default MasterLayout