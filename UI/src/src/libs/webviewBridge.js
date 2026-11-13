export const isWebView =
  typeof window !== "undefined" && !!window.chrome?.webview;

const listeners = new Set();
const buffer = [];
let flushing = false;

if (isWebView) {
  window.chrome.webview.addEventListener("message", (event) => {
    const msg = event.data;
    if (listeners.size === 0) {
      buffer.push(msg);
      return;
    }
    listeners.forEach((fn) => fn(msg));
  });
}

export function subscribeToWebView(fn) {
  listeners.add(fn);

  if (buffer.length > 0 && !flushing) {
    flushing = true;
    const pending = buffer.splice(0);
    pending.forEach((msg) => fn(msg));
    flushing = false;
  }

  return () => listeners.delete(fn);
}

export function postToCSharp(msg) {
  if (isWebView) window.chrome.webview.postMessage(msg);
}
