import Button from "../../../components/Button.jsx";
import { useEffect, useState } from "preact/hooks";
import { subscribeToWebView } from "../../../libs/webviewBridge.js";
import { useLocation, useRoute } from "preact-iso";

const AddKnowledgePage = () => {
  const [loading, setLoading] = useState(false);

  const { url, route } = useLocation();

  const [knowledge, setKnowledge] = useState({
    name: "",
    value: "",
    type: 0,
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);

    if (knowledge.name.trim() === "" || knowledge.value.trim() === "") {
      alert("Please enter correct data.");
      return;
    }

    window.chrome.webview.postMessage({
      method: "add-knowledge",
      data: knowledge,
    });
  };

  const handleChange = (e) => {
    setKnowledge({
      ...knowledge,
      [e.target.name]: e.target.value,
    });
  };

  const handleSuccess = () => {
    setLoading(false)

    route("/knowledge")
  };

  useEffect(() => {
    return subscribeToWebView((msg) => {
      if (msg?.type === "add-knowledge") {
        handleSuccess()
      }
    });
  }, []);

  return (
    <>
      <section className={"max-w-3xl mx-auto pt-2 h-full"}>
        <div className={"flex flex-col gap-1 w-full mb-8 relative"}>
          <h1
            className={
              "m-0 wrap-break-word  text-[24px] tracking-[0.8px] text-[#0d0d0d]"
            }
          >
            Add Knowledge
          </h1>
          <p className={"text-base text-gray-600 text-balance font-light"}>
            add knowledge and data to your ai context
          </p>
          <Button
            link={"/knowledge"}
            className={
              "flex gap-2 flex-row! absolute top-1/2 -translate-y-1/2 right-0 w-20"
            }
            variant={"secondary"}
          >
            Back
          </Button>
        </div>

        <div className={"space-y-4"}>
          <form onSubmit={handleSubmit} className={"flex flex-col gap-4"}>
            <label
              for="name"
              className={
                "bg-gray-50 block w-full p-4 border border-gray-200 rounded-2xl"
              }
            >
              Name: <span className={"text-red-500"}>*</span>
              <input
                id={"name"}
                type="text"
                name={"name"}
                value={knowledge.name}
                onInput={handleChange}
                className={
                  "w-full bg-white border border-gray-200 rounded-xl mt-4 h-10 px-3 focus:outline-0 text-sm placeholder:text-sm"
                }
                placeholder={"Coding Knowledge"}
              />
            </label>
            <label
              for="value"
              className={
                "bg-gray-50 block w-full p-4 border border-gray-200 rounded-2xl"
              }
            >
              Value: <span className={"text-red-500"}>*</span>
              <textarea
                id={"value"}
                name={"value"}
                onInput={handleChange}
                className={
                  "w-full bg-white border border-gray-200 rounded-xl min-h-30 mt-4 p-3 focus:outline-0 text-sm placeholder:text-sm"
                }
                placeholder={"Knowledge Value"}
              >{knowledge.value}</textarea>
            </label>
            <Button type={"submit"} className={"w-48"} loading={loading}>
              Submit & Process
            </Button>
          </form>
        </div>
      </section>
    </>
  );
};

export default AddKnowledgePage;
