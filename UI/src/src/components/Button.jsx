import clsx from "clsx";
import { IconLoader2 } from "@tabler/icons-preact";

const variantClasses = {
  primary: "bg-green-500 text-white hover:bg-green-600 active:bg-green-700",
  secondary: "bg-gray-100 text-gray-800 hover:bg-gray-200 active:bg-gray-300",
  danger: "bg-red-500 text-white hover:bg-red-600 active:bg-red-700",
  outline:
    "border border-gray-300 text-gray-800 hover:bg-gray-50 active:bg-gray-100",
};

const sizeClasses = {
  sm: "px-3 py-1.5 text-sm gap-1.5",
  md: "px-4 py-2 text-base gap-2",
  lg: "px-5 py-2.5 text-lg gap-2.5",
};

const Button = ({
  children,
  className,

  variant = "primary",
  size = "md",

  loading = false,
  disabled = false,

  type = "button",

  ...props
}) => {
  const isDisabled = disabled || loading;

  return (
    <button
      type={type}
      disabled={isDisabled}
      className={clsx(
        "inline-flex items-center justify-center rounded-xl font-medium",
        "transition-all duration-150 cursor-pointer select-none",
        "disabled:opacity-50 disabled:pointer-events-none",
        "active:scale-[0.98]",
        variantClasses[variant],
        sizeClasses[size],
        className,
      )}
      {...props}
    >
      {loading && (
        <IconLoader2 className="animate-spin" size={18} />
      )}

      {children && <span>{children}</span>}
    </button>
  );
};

export default Button;
