// import { useState } from "react";
import Header from "./components/Header/header";
import Footer from "./components/Footer/footer";
import Dashboard from "./pages/Dashboard";

function App() {
  // const [count, setCount] = useState(0)

  return (
    <>
      <Header />
      <div className={"container-fluid"}>
        <Dashboard />
      </div>
      <Footer />
    </>
  );
}

export default App;
