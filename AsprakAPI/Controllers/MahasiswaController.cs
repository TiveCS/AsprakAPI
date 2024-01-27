using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsprakAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MahasiswaController : ControllerBase
	{

		private readonly Mahasiswa mhs1 = new Mahasiswa(), mhs2 = new Mahasiswa();

		protected Dictionary<string, Mahasiswa> mahasiswaList = new Dictionary<string, Mahasiswa>();

		private readonly ILogger<MahasiswaController> _logger;

		public MahasiswaController(ILogger<MahasiswaController> logger)
		{
			_logger = logger;

			mhs1.Name = "Ahmad";
			mhs2.Name = "Fathan";

			mhs1.NIM = "1111111111";
			mhs2.NIM = "1302204090";

			mahasiswaList.Add(mhs1.NIM, mhs1);
			mahasiswaList.Add(mhs2.NIM, mhs2);
		}


		[HttpGet]
		public IEnumerable<Mahasiswa> Get()
		{
			return mahasiswaList.Values.AsEnumerable();
		}

		[HttpPost]
		public IEnumerable<Mahasiswa> Post([FromBody] Mahasiswa mahasiswa)
		{
			mahasiswaList.Add(mahasiswa.NIM, mahasiswa);

			return mahasiswaList.Values.AsEnumerable();
		}

		[HttpPut("{nim}")]
		public Mahasiswa? Put(string nim, [FromBody] Mahasiswa mahasiswa)
		{
			Mahasiswa? mhs = mahasiswaList.First((m) => m.Value.NIM.Equals(nim)).Value;

			if (mhs == null) return null;

			mahasiswaList.Remove(nim);
			mahasiswaList.Add(nim, mhs);

			return mahasiswa;
		}

		[HttpDelete("{nim}")]
		public IEnumerable<Mahasiswa> Delete(string nim)
		{
			mahasiswaList.Remove(nim);

			return mahasiswaList.Values.AsEnumerable();
		}

		[HttpGet("{nim}")]
		public Mahasiswa? GetByNim(string nim)
		{
			Mahasiswa? mhs = mahasiswaList.First((m) => m.Value.NIM.Equals(nim)).Value;

			if (mhs == null) return null;

			return mhs;
		}

	}
}
