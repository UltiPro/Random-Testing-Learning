def todo(func):
    def wrapper(*args, **keywords):
        return func(*args, **keywords).upper()
    return wrapper


@todo
def foo(name):
    return name


print(foo("cosiek"))
