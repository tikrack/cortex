const HomePage = () => {
    return <>
        <main class="min-h-screen flex items-center justify-center bg-slate-950">
            <div class="rounded-2xl bg-slate-900 p-8 text-white shadow-xl">
                <h1 class="text-2xl font-bold">
                    Hello Preact!
                </h1>

                <p class="mt-3 text-slate-400">
                    Lightweight frontend stack.
                </p>

                <button class="mt-6 rounded-lg bg-cyan-500 px-5 py-2 font-semibold hover:bg-cyan-400">
                    Get Started
                </button>
            </div>
        </main>
    </>
}

export default HomePage;