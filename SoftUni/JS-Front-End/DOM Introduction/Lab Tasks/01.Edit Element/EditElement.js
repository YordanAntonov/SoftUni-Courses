function editElement(ref, match, replacer) {
  const regex = RegExp(match, "g");
  ref.textContent = ref.textContent.replace(regex, replacer);
}
