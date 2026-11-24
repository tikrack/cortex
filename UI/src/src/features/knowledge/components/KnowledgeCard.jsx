import { IconBrain, IconPuzzle, IconTrash } from "@tabler/icons-preact";
import { useEffect } from "preact/hooks";
import { subscribeToWebView } from "../../../libs/webviewBridge.js";

const KnowledgeCard = ({ knowledge, getKnowledge }) => {
  const handleDelete = () => {
    if (!confirm("Are you sure about your work?")) return;

    window.chrome.webview.postMessage({
      method: "delete-knowledge",
      data: {
        id: knowledge.id
      },
    });
  };

  useEffect(() => {
    return subscribeToWebView((msg) => {
      if (msg?.type === "delete-knowledge") {
        getKnowledge();
      }
    });
  }, [])

  return (
    <div className="bg-gray-50 p-4 rounded-3xl border border-gray-200 flex flex-col gap-4">
      <div className="flex items-start justify-between gap-3">
        <div className="flex items-center gap-3 min-w-0">
          <div className="w-11 h-11 shrink-0 rounded-2xl bg-cyan-100 text-cyan-700 flex items-center justify-center">
            <IconBrain size={23} stroke={1.8} />
          </div>

          <div className="min-w-0">
            <h3 className="font-bold text-gray-800 truncate">
              {knowledge.name}
            </h3>

            <p className="text-xs text-gray-400 mt-1">Type: {knowledge.type}</p>
          </div>
        </div>

        <span className="text-xs px-3 py-1.5 rounded-full font-medium bg-gray-200 text-gray-700 whitespace-nowrap">
          Status: {knowledge.status}
        </span>
      </div>

      <div className="bg-white border border-gray-100 rounded-2xl p-3">
        <p className="text-xs text-gray-400 mb-2">Content</p>

        <p className="text-sm text-gray-700 leading-6 whitespace-pre-wrap break-words line-clamp-4">
          {knowledge.value || "No content available."}
        </p>
      </div>

      <div className="bg-white border border-gray-100 rounded-2xl p-3 flex items-center justify-between">
        <div className="flex items-center gap-2 text-gray-500 text-sm">
          <IconPuzzle size={18} stroke={1.8} />
          Chunks
        </div>

        <span className="font-bold text-gray-800 text-lg">
          {knowledge.chunks?.length ?? 0}
        </span>
      </div>

      <div className="pt-3 border-t border-gray-200 flex items-center justify-between gap-3">
        <span className="text-[11px] text-gray-400 break-all min-w-0">
          ID: {knowledge.id}
        </span>

        <button
          type="button"
          onClick={handleDelete}
          className="cursor-pointer active:scale-95 shrink-0 w-9 h-9 rounded-xl bg-red-50 border border-red-100 text-red-500 hover:bg-red-100 hover:text-red-600 transition flex items-center justify-center"
          title="Delete Knowledge"
        >
          <IconTrash size={18} stroke={1.8} />
        </button>
      </div>
    </div>
  );
};

export default KnowledgeCard;
