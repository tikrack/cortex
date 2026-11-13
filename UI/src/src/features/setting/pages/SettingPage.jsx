import { useEffect, useState } from "preact/hooks";
import PageLoading from "../../../components/PageLoading.jsx";
import { subscribeToWebView } from "../../../libs/webviewBridge.js";

const SettingPage = () => {
  const [loading, setLoading] = useState(true);
  const [settings, setSettings] = useState([]);

  useEffect(() => {
    return subscribeToWebView((msg) => {
      console.log(msg);
    });
  }, []);

  return (
    <>
      <section className={"max-w-3xl mx-auto pt-2 h-full"}>
        <div className={"flex flex-col gap-1 w-full mb-8"}>
          <h1
            className={
              "m-0 wrap-break-word  text-[24px] tracking-[0.8px] text-[#0d0d0d]"
            }
          >
            Settings
          </h1>
          <p className={"text-base text-gray-600 text-balance font-light"}>
            Review your app settings
          </p>
        </div>

        {loading && (
          <div className={"mt-20"}>
            <PageLoading />
          </div>
        )}
      </section>
    </>
  );
};

export default SettingPage;