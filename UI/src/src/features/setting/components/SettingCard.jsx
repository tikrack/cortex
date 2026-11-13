import { useEffect, useState } from "preact/hooks";
import Button from "../../../components/Button.jsx";

const SettingCard = ({ setting: s }) => {
  const [setting, setSetting] = useState(s);

  const handleSave = () => {

  };

  return (
    <div
      className={"bg-gray-50 p-4 rounded-3xl border border-gray-200 relative"}
    >
      <h3 className={"text-gray-600 font-bold"}>{setting.name}</h3>
      <p className={"text-gray-400 text-sm mt-1.25"}>{setting.description}</p>
      <input
        type="text"
        className={
          "w-full bg-white border border-gray-200 rounded-xl mt-4 h-10 px-3 focus:outline-0 text-sm placeholder:text-sm"
        }
        placeholder={"Enter your value..."}
        onInput={(event) =>
          setSetting({ ...setting, value: event.target.value })
        }
      />
      <Button
        onClick={handleSave}
        className={"absolute top-4 right-4"}
        disabled={s.value === setting.value}
      >
        Save
      </Button>
    </div>
  );
};

export default SettingCard;
