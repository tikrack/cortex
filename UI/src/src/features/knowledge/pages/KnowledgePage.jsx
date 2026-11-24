import PageLoading from "../../../components/PageLoading.jsx";
import Button from "../../../components/Button.jsx";
import { useEffect, useState } from "preact/hooks";
import KnowledgeCard from "../components/KnowledgeCard.jsx";
import { subscribeToWebView } from "../../../libs/webviewBridge.js";

const KnowledgePage = () => {
  const [loading, setLoading] = useState(true);
  const [knowledge, setKnowledge] = useState([]);

  const getKnowledge = () => {
    window.chrome.webview.postMessage({
      method: "all-knowledge",
    });
  }

  useEffect(() => {
    getKnowledge();

    return subscribeToWebView((msg) => {
      if (msg?.type === "all-knowledge") {
        setKnowledge(msg.data);
        setLoading(false);
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
            Knowledge
          </h1>
          <p className={"text-base text-gray-600 text-balance font-light"}>
            Review your app knowledge and data for ai learning
          </p>
          <Button
            link={"knowledge/add"}
            className={
              "flex gap-2 flex-row! absolute top-1/2 -translate-y-1/2 right-0 w-40"
            }
          >
            Add Knowledge
          </Button>
        </div>

        {loading ? (
          <div className={"mt-20"}>
            <PageLoading />
          </div>
        ) : (
          <div className={"space-y-4 pb-10"}>
            {knowledge.map((kn, index) => (
              <KnowledgeCard
                getKnowledge={getKnowledge}
                knowledge={kn}
                key={`knowledge-${index}`}
              />
            ))}

            {!loading && knowledge.length === 0 && (
              <div
                className={
                  "bg-gray-50 p-4 py-10 rounded-3xl border border-dashed border-gray-300 text-center text-gray-700"
                }
              >
                The Knowledge list is <empty class=""></empty>
              </div>
            )}
          </div>
        )}
      </section>
    </>
  );
};

export default KnowledgePage;
